using Encryption.Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Encryption.Class
{
    class RSACryptor : IAsyncEncryption
    {
        readonly RSACryptoServiceProvider rsa;

        public RSACryptor()
        {
            rsa =  new RSACryptoServiceProvider(2048);
        }
        public RSACryptor(int bitsAmount)
        {
            rsa = new RSACryptoServiceProvider(bitsAmount);
        }

        public byte[] Encrypt(byte[] rawData)
        {
            try
            {
                byte[] encryptedData;
                encryptedData = rsa.Encrypt(rawData, true);
                return encryptedData;
            }
            catch
            {
                return null;
            }
        }

        public byte[] Decrypt(byte[] encryptedData)
        {
            try
            {
                byte[] decryptedData;
                decryptedData = rsa.Decrypt(encryptedData, true);

                return decryptedData;
            }
            catch
            {
                return null;
            }
        }

        public byte[] GetPublicKey()
        {
            return rsa.ExportCspBlob(false);
        }
        
        public RSAParameters GetParameters()
        {
            return rsa.ExportParameters(false);
        }

        public void AddPublicKey(byte[] key)
        {
            rsa.ImportCspBlob(key);
        }
    }
}
