using PositionSharing.Communication;
using PositionSharing.Model;
using PositionSharing.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharing.Action
{
    public class ActionHandler
    {
        private ICommunicationManager communicationManager;
        private IStorageManager storageManager;
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public ActionHandler(ICommunicationManager communicationManager, IStorageManager storageManager)
        {
            this.communicationManager = communicationManager;
            this.storageManager = storageManager;
        }

        /// <summary>
        /// creates a group
        /// </summary>
        /// <param name="title">the title of the group</param>
        public async Task CreateGroupAsync(string title)
        {
            await Task.Delay(1);
            Group group = communicationManager.CreateGroup(title,username);
            if (group.GroupKey.Length > 1)
            {
                storageManager.SaveGroup(group);
            }
        }
    }
}
