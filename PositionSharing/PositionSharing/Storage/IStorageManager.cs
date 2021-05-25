using PositionSharing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharing.Storage
{
    public interface IStorageManager
    {
        void SaveGroup(Group group);
        bool ContainsGroup(Group group);
        void DeleteGroup(Group group);
    }
}
