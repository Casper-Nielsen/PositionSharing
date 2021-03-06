using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption.Interface
{
    public interface IAsyncEncryption
    {
        byte[] GetPublicKey();
        void AddPublicKey(byte[] key);
        byte[] Encrypt(byte[] rawData);
        byte[] Decrypt(byte[] encryptedData);
    }
}
