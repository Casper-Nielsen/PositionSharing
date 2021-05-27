using PositionSharing.Listener;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharing.Communication
{
    public interface IBroadcaster
    {
        void AddListener(ref IGroupListener listener);
        void RemoveListener(ref IGroupListener listener);
        Task GetGroupsAsync();
        void StopGettingGroups();
    }
}
