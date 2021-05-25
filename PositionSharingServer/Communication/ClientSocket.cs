using CommunicationModels.Enum;
using CommunicationModels.Factory;
using CommunicationModels.Models;
using Google.Protobuf;
using PositionSharingServer.Action;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PositionSharingServer.Communication
{
    class ClientSocket : IClientSocket
    {
        private Task clientTask;
        private Socket socket;
        private TcpClient client;
        private ActionHandler handler;
        private IClientSocket itself;
        private int errors = 0;
        private object socket_Lock = new object();

        public ClientSocket(TcpClient client, ref ActionHandler handler)
        {
            this.itself = this;
            this.client = client;
            this.handler = handler;
            socket = this.client.Client;
            clientTask = Run();
        }

        private async Task Run()
        {
            await Task.Delay(1);
            int lenght;
            byte[] buffer;
            while (client.Connected && socket.Connected)
            {
                buffer = new byte[64000];
                try
                {
                    lenght = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                    OuterMessage outerMessage = OuterMessage.Parser.ParseFrom(Format(buffer,lenght));
                    switch (outerMessage.MType)
                    {
                        case OuterMessage.Types.MessageType.Error:
                            errors++;
                            break;
                        case OuterMessage.Types.MessageType.Response:
                            break;
                        case OuterMessage.Types.MessageType.Request:
                            switch (outerMessage.RType)
                            {
                                case OuterMessage.Types.RequestType.Creategroup:

                                    _ = Task.Run(new System.Action(() => handler.CreateGroup(ref itself, CommunicationModels.Models.Group.Parser.ParseFrom(outerMessage.Message))));
                                    break;
                            }
                            break;
                        case OuterMessage.Types.MessageType.Pulse:
                            errors = 0;
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    errors++;
                }
            }
        }

        /// <summary>
        /// sends a message to the client
        /// </summary>
        /// <param name="message">the message to send</param>
        /// <param name="messageType">the type of message</param>
        /// <param name="requestType">the request type</param>
        public void Send(IMessage message, MessageType messageType, RequestType requestType)
        {
            lock (socket_Lock)
            {
                if (socket.Connected)
                {
                    IMessage outerMessage = MessageFactory.Create(messageType, requestType, message);
                    socket.Send(outerMessage.ToByteArray());
                }
            }
        }

        /// <summary>
        /// Resizes the buffer to the given lenght
        /// </summary>
        /// <param name="buffer">the buffer to resize</param>
        /// <param name="lenght">the lenght of the resized data</param>
        /// <returns></returns>
        private byte[] Format(byte[] buffer, int lenght)
        {
            Array.Resize<byte>(ref buffer, lenght);
            return buffer;
        }
    }
}
