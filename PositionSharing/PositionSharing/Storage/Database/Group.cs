using SQLite;

namespace PositionSharing.Storage.Database
{
    public class Group
    {
        public Group() { }
        public Group(Model.Group group)
        {
            GroupKey = group.GroupKey;
            Title = group.Title;
            UserGroupKey = group.UserGroupKey;
        }
        [PrimaryKey]
        public string GroupKey { get; set; }
        public string Title { get; set; }
        public string UserGroupKey { get; set; }
    }
}
