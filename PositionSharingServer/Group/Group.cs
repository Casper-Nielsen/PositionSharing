using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharingServer.Group
{
    class Group
    {
        private string title;
        private string groupKey;
        private string userGroupKey;

        public string UserGroupKey
        {
            get { return userGroupKey; }
            set { userGroupKey = value; }
        }
        public string GroupKey
        {
            get { return groupKey; }
            set { groupKey = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public Group(string groupKey)
        {
            GroupKey = groupKey;
        }
        public Group(string title, string groupKey) : this(groupKey)
        {
            Title = title;
        }
        public Group(string title, string groupKey, string userGroupKey) : this(title, groupKey)
        {
            UserGroupKey = userGroupKey;
        }
    
        /// <summary>
        /// generates a userkey for that group
        /// </summary>
        /// <param name="user">users name</param>

    }
}
