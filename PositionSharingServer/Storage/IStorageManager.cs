using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharingServer.Storage
{
    public interface IStorageManager
    {
        public bool ContainsKey(string key);
        public void CreateGroup(string groupName, string groupKey);
        public void AddToGroup(string groupKey, string user);
        public void DeleteUser(string groupKey, string userKey);
    }
}
