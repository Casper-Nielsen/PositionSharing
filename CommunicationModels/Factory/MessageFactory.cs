using static CommunicationModels.Models.OuterMessage.Types;
using CommunicationModels.Models;
using Google.Protobuf;

namespace CommunicationModels.Factory
{
    public class MessageFactory
    {
        /// <summary>
        /// Creates a OuterMessage containing a message
        /// </summary>
        /// <param name="messageType">the message type</param>
        /// <param name="message">the message</param>
        /// <returns>the outer message</returns>
        public static OuterMessage Create(MessageType messageType, IMessage message)
        {
            OuterMessage outerMessage = new OuterMessage();
            outerMessage.MType = messageType;
            outerMessage.Message = message.ToByteString();
            return outerMessage;
        }

        /// <summary>
        /// Creates a OuterMessage containing a message
        /// </summary>
        /// <param name="messageType">the message type</param>
        /// <param name="requestType">the request type</param>
        /// <param name="message">the message</param>
        /// <returns>the outer message</returns>
        public static OuterMessage Create(MessageType messageType, RequestType requestType, IMessage message)
        {
            OuterMessage outerMessage = new OuterMessage();
            outerMessage.MType = messageType;
            outerMessage.RType = requestType;
            outerMessage.Message = message.ToByteString();
            return outerMessage;
        }

        /// <summary>
        /// Parses the buffer to a OuterMessage
        /// </summary>
        /// <param name="buffer">the buffer containing only the OuterMessage</param>
        /// <returns>the OuterMessage</returns>
        public static OuterMessage Create(byte[] buffer)
        {
            OuterMessage outerMessage = OuterMessage.Parser.ParseFrom(buffer);
            return outerMessage;
        }
    }
}
