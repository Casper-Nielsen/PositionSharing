using Encryption.Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Encryption.Class
{
    class HmacHashing : IHMAC
    {
        private HMAC hmac;

        public HmacHashing(byte[] key, string hashingType)
        {
            SetHashingType(hashingType);
            hmac.Key = key;
        }
 
        /// <summary>
        /// sets the hashing type
        /// </summary>
        /// <param name="hashingType">the hashing type</param>
        private void SetHashingType(string hashingType)
        {
            // Switch case to find the hashing class
            switch(hashingType.ToLower())
            {
                case "sha1":
                    hmac = new HMACSHA1();
                    break;
                case "sha256":
                    hmac = new HMACSHA256();
                    break;
                case "sha384":
                    hmac = new HMACSHA384();
                    break;
                case "sha512":
                    hmac = new HMACSHA512();
                    break;
                default:
                    hmac = new HMACSHA1();
                    break;
            };
        }

        /// <summary>
        /// hashes the message with the hashing type that is set using the key
        /// </summary>
        /// <param name="message">the message that will be hashed</param>
        /// <returns>the hashed data</returns>
        public byte[] ComputeMAC(byte[] message, byte[] salt)
        {
            byte[] mac = new byte[0];
            try
            {
                mac = hmac.ComputeHash(Combind(message, salt));
            }
            catch { }
            return mac;
        }

        /// <summary>
        /// generates a salt array using RNGCryptoServiceProvider
        /// </summary>
        /// <param name="lenght">the lenght of the salt</param>
        /// <returns>the salt</returns>
        public byte[] GenerateSalt(int lenght)
        {
            byte[] salt = new byte[lenght];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        /// <summary>
        /// Combinds 2 arrays into one
        /// </summary>
        /// <param name="array1">the first array</param>
        /// <param name="array2">the second array</param>
        /// <returns>the full array</returns>
        private byte[] Combind(byte[] array1, byte[] array2)
        {
            byte[] buffer = new byte[array1.Length + array2.Length];
            Buffer.BlockCopy(array1, 0, buffer, 0, array1.Length);
            Buffer.BlockCopy(array2, 0, buffer, array1.Length, array2.Length);
            return buffer;
        }
    }
}
