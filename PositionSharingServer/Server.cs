using PositionSharingServer.Action;
using PositionSharingServer.Communication;
using PositionSharingServer.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharingServer
{
    class Server
    {
        private List<IClientSocket> clients;
        private TcpListener tcpServer;
        private ActionHandler actionHandler;
        public bool connectionAllowed;

        /// <summary>
        /// Start listing for connections
        /// Creates a iclientSocket foreach client connected
        /// </summary>
        public void Start()
        {
            actionHandler = new ActionHandler(new MSSQLManager(@"(localdb)\MSSQLLocalDB"));
            clients = new List<IClientSocket>();
            connectionAllowed = true;
            string ip = LocalIPAddress().ToString();
            int port = 5002;
            tcpServer = new TcpListener(IPAddress.Parse(ip), port);
            tcpServer.Start();
            Console.WriteLine("Server has started on {0}:{1}, Waiting for a connection...", ip, port);
            while (connectionAllowed)
            {
                clients.Add(ClientSocketFactory.Create(ref actionHandler, tcpServer.AcceptTcpClient()));
                Console.WriteLine("new client");
            }
        }

        /// <summary>
        /// Finds the local IP Address
        /// </summary>
        /// <returns>the ip adress</returns>
        private IPAddress LocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            return host
               .AddressList
               .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}
