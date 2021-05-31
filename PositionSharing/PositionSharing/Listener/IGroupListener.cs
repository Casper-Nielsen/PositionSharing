using PositionSharing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharing.Listener
{
    public interface IGroupListener
    {
        void AddGroupToList(Group group);
    }
}
