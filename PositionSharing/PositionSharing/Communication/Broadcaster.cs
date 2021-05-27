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
        private List<IGroupListener> groupListeners;

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
            SendBroadcast();
            await Task.Delay(1);
        }

        public void StopGettingGroups()
        {
            gettingGroups = false;
        }
        public void StartReplying()
        {
        }

        private void SendBroadcast()
        {
            byte[] buffer = new byte[1024];
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            socket.Connect(new IPEndPoint(IPAddress.Broadcast, 16789));
            socket.Send(Encoding.UTF8.GetBytes("Anyone out there?"));

            var ep = socket.LocalEndPoint;

            socket.Close();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Bind(ep);
            socket.Receive(buffer);
            var data = Encoding.UTF8.GetString(buffer);
            Console.WriteLine("Got reply: " + data);

            socket.Close();
        }

        private void ReceiveBroadcast()
        {
            byte[] buffer = new byte[1024];

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            var iep = new IPEndPoint(IPAddress.Any, 16789);
            socket.Bind(iep);

            var ep = iep as EndPoint;
            socket.ReceiveFrom(buffer, ref ep);
            var data = Encoding.UTF8.GetString(buffer);

            Console.WriteLine("Received broadcast: " + data + " from: " + ep.ToString());

            buffer = Encoding.UTF8.GetBytes("Yeah me!");
            socket.SendTo(buffer, ep);

            socket.Close();
        }
    }
}
