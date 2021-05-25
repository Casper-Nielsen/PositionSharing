using PositionSharingServer.Communication;
using PositionSharingServer.Group;
using PositionSharingServer.Storage;
using CommunicationModels.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharingServer.Action
{
    class ActionHandler
    {
        IStorageManager storageManager;
        public ActionHandler(IStorageManager storageManager)
        {
            this.storageManager = storageManager;
        }

        /// <summary>
        /// creates a group and addes the user to it
        /// </summary>
        /// <param name="group">a group with the groupname</param>
        /// <returns></returns>
        public void CreateGroup(ref IClientSocket client, CommunicationModels.Models.Group group)
        {
            bool reRun = false;

            // Creates a key for that group
            string key;
            do
            {
                key = GroupFactory.GenerateKey(group.Title);
                reRun = storageManager.ContainsKey(key);
            } while (reRun);

            Group.Group group1 = GroupFactory.Create(group.Title, key);

            // Saves the group
            storageManager.CreateGroup(group1.Title, group1.GroupKey);
            
            group1.GenerateUserKey(group.User);
            // Addes the user to the group
            storageManager.AddToGroup(group1.GroupKey, group1.UserGroupKey);

            // Sends a responce to the client
            client.Send(
                CommunicationModels.Factory.GroupFactory.Create(
                    group1.Title, 
                    group1.GroupKey, 
                    group1.UserGroupKey),
                MessageType.RESPONSE,
                RequestType.CREATEGROUP);
        }
    }
}
