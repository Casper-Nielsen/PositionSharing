using CommunicationModels.Models;
using Google.Protobuf;
using PositionSharing.Exceptions;
using PositionSharing.Model;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharing.Communication
{
    class SocketCommunicationManager : ICommunicationManager
    {
        TcpClient client;
        Socket socket;
        object socketLock;

        public SocketCommunicationManager()
        {
            socketLock = new object();
            client = new TcpClient();
            _ = Connect();
        }

        /// <summary>
        /// Connects the tcp to the server
        /// </summary>
        private async Task Connect()
        {
            await Task.Delay(1000);
            lock (socketLock)
            {
                client.Connect("172.16.21.10", 5002);
                socket = client.Client;
            }
        }

        /// <summary>
        /// ask server to create a group
        /// </summary>
        /// <param name="title">the title of the group</param>
        /// <returns>the group</returns>
        public Model.Group CreateGroup(string title, string username)
        {
            Model.Group group;
            byte[] responseBuffer;

            // Creates a proto messages
            IMessage messagePart = CommunicationModels.Factory.GroupFactory.CreateForNew(title, username);
            OuterMessage message = CommunicationModels.Factory.MessageFactory.Create(CommunicationModels.Enum.MessageType.REQUEST, CommunicationModels.Enum.RequestType.CREATEGROUP, messagePart);
            
            try
            {
                // Sends and receives data
                lock (socketLock)
                {
                    socket.Send(message.ToByteArray());
                    responseBuffer = Receive();
                }
            }
            catch (Exception e)
            {
                // Throws a custom Exception
                throw new InvalidResponseException("didnt receive anything", e);
            }
            // Converts the received data from the server to a proto message
            OuterMessage outerMessage = OuterMessage.Parser.ParseFrom(responseBuffer);
            if (outerMessage.RType == message.RType)
            {
                // Converts the message to a group proto
                CommunicationModels.Models.Group protoGroup = CommunicationModels.Models.Group.Parser.ParseFrom(outerMessage.Message);
                // Converts the group proto to a group
                group = Factory.GroupFactory.Create(protoGroup.Title, protoGroup.GroupKey, protoGroup.UserGroupKey);
            }
            else
            {
                // Throws a custom Exception
                throw new InvalidResponseException("response type was not as expected");
            }
            return group;
        }

        public bool JoinGroup(Model.Group group)
        {
            throw new NotImplementedException();
        }

        public void LeaveGroup(Model.Group group)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// receives data from the server and resizes the buffer
        /// </summary>
        /// <returns>the resized buffer</returns>
        public byte[] Receive()
        {
            byte[] buffer = new byte[64000];
            int lenght = socket.Receive(buffer);
            Array.Resize<byte>(ref buffer, lenght);
            return buffer;
        }
    }
}
