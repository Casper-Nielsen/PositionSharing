using SQLite;

namespace PositionSharing.Storage.Database
{
    public class Group
    {
        [PrimaryKey]
        public string GroupKey { get; set; }
        public string Title { get; set; }
        public string UserGroupKey { get; set; }
    }
}
