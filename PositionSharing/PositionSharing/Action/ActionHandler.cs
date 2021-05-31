using PositionSharing.Communication;
using PositionSharing.Listener;
using PositionSharing.Model;
using PositionSharing.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharing.Action
{
    public class ActionHandler : IGroupListener
    {
        private ICommunicationManager communicationManager;
        private IStorageManager storageManager;
        private IBroadcaster broadcaster;
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        
        public ActionHandler(ICommunicationManager communicationManager, IStorageManager storageManager, IBroadcaster broadcaster)
        {
            this.communicationManager = communicationManager;
            this.storageManager = storageManager;
            this.broadcaster = broadcaster;
        }

        /// <summary>
        /// Creates a group
        /// </summary>
        /// <param name="title">the title of the group</param>
        public async Task<Group> CreateGroupAsync(string title)
        {
            await Task.Delay(1);
            Group group = communicationManager.CreateGroup(title,username);
            if (group.GroupKey.Length > 1)
            {
                storageManager.SaveGroup(group);
                return group;
            }
            return null;
        }

        /// <summary>
        /// Gets groups from the storages
        /// </summary>
        /// <returns>a list of groups</returns>
        public List<Group> GetLocalGroups()
        {
            return storageManager.GetGroups();
        }

        /// <summary>
        /// Leaves the group
        /// </summary>
        /// <param name="group">the group that the user will leave</param>
        public async Task LeaveGroup(Group group)
        {
            Console.WriteLine("leaving group action ");
            communicationManager.LeaveGroup(group);
            storageManager.DeleteGroup(group);
            await Task.Delay(1);
        }

        /// <summary>
        /// gets all groups where a member is on the local network
        /// </summary>
        public void StartGettingJoinableGroups()
        {
            broadcaster.GetGroupsAsync();
        }

        /// <summary>
        /// gets all groups where a member is on the local network
        /// </summary>
        public void AddGroupToList(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
