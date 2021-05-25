using CommunicationModels.Enum;
using CommunicationModels.Models;
using Google.Protobuf;

namespace CommunicationModels.Factory
{
    public class MessageFactory
    {
        public static OuterMessage Create(OuterMessage.Types.MessageType messageType, IMessage message)
        {
            OuterMessage outerMessage = new OuterMessage();
            outerMessage.MType = messageType;
            outerMessage.Message = message.ToByteString();
            return outerMessage;
        }
        public static OuterMessage Create(MessageType messageType, RequestType requestType, IMessage message)
        {
            OuterMessage outerMessage = new OuterMessage();
            outerMessage.MType = (OuterMessage.Types.MessageType)messageType;
            outerMessage.RType = (OuterMessage.Types.RequestType)requestType;
            outerMessage.Message = message.ToByteString();
            return outerMessage;
        }
    }
}
