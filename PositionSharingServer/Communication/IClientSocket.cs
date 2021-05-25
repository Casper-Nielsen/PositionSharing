using CommunicationModels.Enum;
using Google.Protobuf;

namespace PositionSharingServer.Communication
{
    interface IClientSocket
    {
        public void Send(IMessage message, MessageType messageType, RequestType requestType);
    }
}
