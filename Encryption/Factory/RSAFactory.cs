using Encryption.Class;
using Encryption.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption.Factory
{
    public class RSAFactory
    {
        public static IAsyncEncryption Create()
        {
            return new RSACryptor();
        }
        public static IAsyncEncryption Create(int bitamount)
        {
            return new RSACryptor(bitamount);
        }
        public static IAsyncEncryption Create(byte[] publicKey)
        {
            RSACryptor rsa = new RSACryptor();
            rsa.AddPublicKey(publicKey);
            return rsa;
        }
    }
}
