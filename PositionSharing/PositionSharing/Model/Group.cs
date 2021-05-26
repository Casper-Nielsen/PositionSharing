using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharing.Model
{
    public class Group
    {
        private string title;
        private string groupKey;
        private string userGroupKey;

        public string UserGroupKey
        {
            get { return userGroupKey; }
            private set { userGroupKey = value; }
        }
        public string GroupKey
        {
            get { return groupKey; }
            private set { groupKey = value; }
        }
        public string Title
        {
            get { return title; }
            private set { title = value; }
        }

        public Group(string groupKey) {
            GroupKey = groupKey;
        }
        public Group(Storage.Database.Group group)
        {
            GroupKey = group.GroupKey;
            Title = group.Title;
            UserGroupKey = group.UserGroupKey;
        }
        public Group(string title, string groupKey) : this(groupKey)
        {
            Title = title;
        }
        public Group(string title, string groupKey, string userGroupKey) : this(title, groupKey)
        {
            UserGroupKey = userGroupKey;
        }
    }
}
