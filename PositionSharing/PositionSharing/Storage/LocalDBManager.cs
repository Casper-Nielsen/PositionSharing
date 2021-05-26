using PositionSharing.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharing.Storage
{
    class LocalDBManager : IStorageManager
    {
        private Database.Database database;
        public LocalDBManager()
        {
            database = new Database.Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "groups.db3"));
        }
        public bool ContainsGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(Group group)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// gets all the groups from the database
        /// </summary>
        /// <returns>a list of groups</returns>
        public List<Group> GetGroups()
        {
            Task<List<Database.Group>> task = database.GetGroupAsync();
            task.Wait();
            List<Database.Group> databaseGroups = task.Result;
            List<Group> groups = new List<Group>();
            foreach (Database.Group item in databaseGroups)
            {
                groups.Add(new Group(item));
            }
            return groups;
        }

        /// <summary>
        /// saves a group in the database
        /// </summary>
        /// <param name="group">the group that will be saved</param>
        public void SaveGroup(Group group)
        {
            database.SaveGroupAsync(new Database.Group(group)).Wait();
        }
    }
}
