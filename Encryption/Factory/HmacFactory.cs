using Encryption.Class;
using Encryption.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption.Factory
{
    public class HmacFactory
    {
        public static IHMAC Create(byte[] key)
        {
            return new HmacHashing(key, "sha256");
        }

        public static IHMAC Create(byte[] key, string hashingType)
        {
            return new HmacHashing(key, hashingType);
        }

    }
}
