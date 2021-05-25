using CommunicationModels.Models;
using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationModels.Factory
{
    public class GroupFactory
    {
        public static IMessage Create(string groupKey)
        {
            Group group = new Group();
            group.GroupKey = groupKey;
            return group;
        }
        public static IMessage Create(string title, string groupKey)
        {
            Group group = new Group();
            group.GroupKey = groupKey;
            group.Title = title;
            return group;
        }
        public static IMessage Create(string title, string groupKey, string userGroupKey)
        {
            Group group = new Group();
            group.GroupKey = groupKey;
            group.Title = title;
            group.UserGroupKey = userGroupKey;
            return group;
        }
        public static IMessage CreateForNew(string title, string user)
        {
            Group group = new Group();
            group.Title = title;
            group.User = user;
            return group;
        }
        public static IMessage CreateForJoin(string groupKey, string user)
        {
            Group group = new Group();
            group.GroupKey = groupKey;
            group.User = user;
            return group;
        }
    }
}
