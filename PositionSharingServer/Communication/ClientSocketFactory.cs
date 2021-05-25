using PositionSharingServer.Action;
using System.Net.Sockets;

namespace PositionSharingServer.Communication
{
    class ClientSocketFactory
    {
        public static IClientSocket Create(ref ActionHandler actionHandler, TcpClient client)
        {
            return new ClientSocket(client, ref actionHandler);
        }
    }
}
