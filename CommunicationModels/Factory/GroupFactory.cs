using CommunicationModels.Models;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationModels.Factory
{
    public class GroupFactory
    {
        /// <summary>
        /// creates a Group as a IMessage from protobuf
        /// </summary>
        /// <param name="groupKey">the key for the group</param>
        /// <returns>the group as IMessage</returns>
        public static IMessage Create(string groupKey)
        {
            Group group = new Group();
            group.GroupKey = groupKey;
            return group;
        }
        /// <summary>
        /// creates a Group as a IMessage from protobuf
        /// </summary>
        /// <param name="title">the title of the group</param>
        /// <param name="groupKey">the key for the group</param>
        /// <returns>the group as IMessage</returns>
        public static IMessage Create(string title, string groupKey)
        {
            Group group = new Group();
            group.GroupKey = groupKey;
            group.Title = title;
            return group;
        }
        /// <summary>
        /// creates a Group as a IMessage from protobuf
        /// </summary>
        /// <param name="title">the title of the group</param>
        /// <param name="groupKey">the key for the group</param>
        /// <param name="userGroupKey">the users key for that group</param>
        /// <returns>the group as IMessage</returns>
        public static IMessage Create(string title, string groupKey, string userGroupKey)
        {
            Group group = new Group();
            group.GroupKey = groupKey;
            group.Title = title;
            group.UserGroupKey = userGroupKey;
            return group;
        }

        /// <summary>
        /// creates a Group as a IMessage from protobuf without a group key
        /// </summary>
        /// <param name="title">the title of the group</param>
        /// <param name="user">the user that creates the group</param>
        /// <returns>the group as IMessage</returns>
        public static IMessage CreateForNew(string title, string user)
        {
            Group group = new Group();
            group.Title = title;
            group.User = user;
            return group;
        }

        /// <summary>
        /// creates a Group as a IMessage from protobuf when a user joins a group
        /// </summary>
        /// <param name="title">the title of the group</param>
        /// <param name="groupKey">the key for the group</param>
        /// <param name="user">the user that creates the group</param>
        /// <returns>the group as IMessage</returns>
        public static IMessage CreateForJoin(string title, string groupKey, string user)
        {
            Group group = new Group();
            group.Title = title;
            group.GroupKey = groupKey;
            group.User = user;
            return group;
        }
        
        /// <summary>
        /// Parses the buffer to a group
        /// </summary>
        /// <param name="buffer">the buffer containing only the group</param>
        /// <returns>the group</returns>
        public static Group Create(byte[] buffer)
        {
            Group group = Group.Parser.ParseFrom(buffer);
            return group;
        }
    }
}
