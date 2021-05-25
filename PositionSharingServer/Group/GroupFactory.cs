using Encryption.Factory;
using Encryption.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharingServer.Group
{
    class GroupFactory
    {
        /// <summary>
        /// generates a key for the group
        /// </summary>
        /// <param name="groupName">the name of the group that will be used to generate</param>
        /// <returns>the key</returns>
        public static string GenerateKey(string groupName)
        {
            IHMAC hmac = HmacFactory.Create(Encoding.Unicode.GetBytes(groupName));
            byte[] salt = hmac.GenerateSalt(16);
            return Convert.ToBase64String(hmac.ComputeMAC(BitConverter.GetBytes(DateTime.Now.Ticks), salt));
        } 

        public static Group Create(string name, string key)
        {
            return new Group(name, key);
        }
    }
}
