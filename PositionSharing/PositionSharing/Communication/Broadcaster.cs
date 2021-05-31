using CommunicationModels.Models;
using CommunicationModels.Factory;
using Encryption.Factory;
using Encryption.Interface;
using Google.Protobuf;
using PositionSharing.Listener;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharing.Communication
{
    public class Broadcaster : IBroadcaster
    {
        private bool gettingGroups;
        private bool sendReplys;
        private List<IGroupListener> groupListeners;
        private Action.ActionHandler handler;

        public Broadcaster()
        {
            groupListeners = new List<IGroupListener>();
        }
        public void AddListener(ref IGroupListener listener)
        {
            groupListeners.Add(listener);
        }
        public void RemoveListener(ref IGroupListener listener)
        {
            groupListeners.Remove(listener);
        }

        public async Task GetGroupsAsync()
        {
            gettingGroups = true;
            await SendBroadcastAsync();
        }

        public void StopGettingGroups()
        {
            gettingGroups = false;
        }
        public void StartReplying(ref Action.ActionHandler handler)
        {
            this.handler = handler;
            sendReplys = true;
            Task.Run(new System.Action(ReceiveBroadcast));
        }
        public void StopReplying()
        {
            sendReplys = false;
        }
        private async Task SendBroadcastAsync()
        {
            Task<IAsyncEncryption> rsaTask = Task<IAsyncEncryption>.Run(() =>
            {
                return RSAFactory.Create(2048);
            });
            byte[] buffer = new byte[1024 * 8];
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            socket.Connect(new IPEndPoint(IPAddress.Broadcast, 16789));
            await rsaTask;
            IAsyncEncryption rsa = rsaTask.Result;
            IMessage message = KeyFactory.Create(Key.Types.KeyType.Rsa, rsa.GetPublicKey());
            socket.Send(
                MessageFactory.Create(OuterMessage.Types.MessageType.Request,
                OuterMessage.Types.RequestType.Getgroups,
                message).ToByteArray());

            var ep = socket.LocalEndPoint;

            socket.Close();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Bind(ep);
            socket.Receive(buffer);

            for (int i = 0; i < groupListeners.Count; i++)
            {
                groupListeners[i];
            }

            socket.Close();
        }

        /// <summary>
        /// Receives broad casts and sends its groups back
        /// </summary>
        /// <param name="handler">the action handler</param>
        private void ReceiveBroadcast()
        {
            
            // Setup for Receiving broadcast message on port 16789
            byte[] buffer = new byte[1024 * 8];

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            var iep = new IPEndPoint(IPAddress.Any, 16789);
            socket.Bind(iep);

            var ep = iep as EndPoint;

            // Gets message from broadcast
            int lenght = socket.ReceiveFrom(buffer, ref ep);
            Array.Resize(ref buffer, lenght);
            if (lenght > 1)
            {
                // Gets the RSA encryption
                OuterMessage outerMessage = MessageFactory.Create(buffer);
                if (outerMessage.RType == OuterMessage.Types.RequestType.Getgroups)
                {
                    Key key = KeyFactory.Create(outerMessage.Message.ToByteArray());
                    if (key.Type == Key.Types.KeyType.Rsa)
                    {
                        IAsyncEncryption asyncEncryption = RSAFactory.Create(key.Key_.ToByteArray());

                        // Gets all the groups that the phone knows
                        List<Model.Group> groups = handler.GetLocalGroups();
                        foreach (Model.Group group in groups)
                        {
                            // Converts groups to Communications models group
                            IMessage message = GroupFactory.Create(group.Title, group.GroupKey);

                            // Encrypts group
                            buffer = asyncEncryption.Encrypt(message.ToByteArray());

                            // Sends the encrypted group
                            socket.SendTo(buffer, ep);

                        }
                    }
                }
            }

            socket.Close();
        }
    }
}
