using PositionSharingServer.Communication;
using PositionSharingServer.Group;
using PositionSharingServer.Storage;
using static CommunicationModels.Models.OuterMessage.Types;
using System;

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
            Console.WriteLine("Create Group Started");
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

            group1 = GroupFactory.CompileUserKey(group1, group.User);

            // Addes the user to the group
            storageManager.AddToGroup(group1.GroupKey, group1.UserGroupKey);

            // Sends a responce to the client
            client.Send(
                CommunicationModels.Factory.GroupFactory.Create(
                    group1.Title, 
                    group1.GroupKey, 
                    group1.UserGroupKey),
                MessageType.Response,
                RequestType.Creategroup);
            Console.WriteLine("Create Group completed");
        }
    
        public void RemoveUserFromGroup(ref IClientSocket client, CommunicationModels.Models.Group group)
        {
            Group.Group group1 = GroupFactory.Create(group.Title, group.GroupKey, group.UserGroupKey);
            storageManager.DeleteUser(group1.GroupKey, group1.UserGroupKey);
            client.Send(
                CommunicationModels.Factory.GroupFactory.Create(
                    group1.Title,
                    group1.GroupKey,
                    group1.UserGroupKey),
                MessageType.Response,
                RequestType.Leavegroup);
        }
    }
}
