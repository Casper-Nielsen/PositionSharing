using PositionSharing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharing.Communication
{
    public interface ICommunicationManager
    {
        Group CreateGroup(string title, string username);
        bool JoinGroup(Group group);
        void LeaveGroup(Group group);
    }
}
