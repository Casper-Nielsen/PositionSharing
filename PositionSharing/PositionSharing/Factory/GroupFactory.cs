using PositionSharing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PositionSharing.Factory
{
    class GroupFactory
    {
        static public Group Create(string groupKey)
        {
            return new Group(groupKey);
        }
        static public Group Create(string title, string groupKey)
        {
            return new Group(title, groupKey);
        }
        static public Group Create(string title, string groupKey, string userGroupKey)
        {
            return new Group(title, groupKey, userGroupKey);
        }
    }
}
