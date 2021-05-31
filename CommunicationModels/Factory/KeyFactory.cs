using CommunicationModels.Models;
using Google.Protobuf;

namespace CommunicationModels.Factory
{
    public class KeyFactory
    {
        /// <summary>
        /// creates a Key as a IMessage from protobuf
        /// </summary>
        /// <param name="type">the key type</param>
        /// <param name="keyBytes">the key</param>
        /// <returns>the key as IMessage</returns>
        public static IMessage Create(Key.Types.KeyType type, byte[] keyBytes)
        {
            Key key = new Key
            {
                Type = type,
                Key_ = ByteString.CopyFrom(keyBytes)
            };
            return key;
        }
        /// <summary>
        /// creates a Key as a IMessage from protobuf
        /// </summary>
        /// <param name="type">the key type</param>
        /// <param name="keyBytes">the key</param>
        /// <param name="iv">the iv</param>
        /// <returns>the key as IMessage</returns>
        public static IMessage Create(Key.Types.KeyType type, byte[] keyBytes, byte[] iv)
        {
            Key key = new Key
            {
                Type = type,
                Key_ = ByteString.CopyFrom(keyBytes),
                Iv = ByteString.CopyFrom(iv)
            };
            return key;
        }

        /// <summary>
        /// Parses the buffer to a key
        /// </summary>
        /// <param name="buffer">the buffer containing only the key</param>
        /// <returns>the key</returns>
        public static Key Create(byte[] buffer)
        {
            Key key = Key.Parser.ParseFrom(buffer);
            return key;
        }
    }
}
