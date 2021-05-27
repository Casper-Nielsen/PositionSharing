using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PositionSharing.Storage.Database
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Group>().Wait();
            // _database.DeleteAllAsync<Group>().Wait();
        }

        /// <summary>
        /// Gets all groups in the database
        /// </summary>
        /// <returns>A list of groups</returns>
        public Task<List<Group>> GetGroupAsync()
        {
            return _database.Table<Group>().ToListAsync();
        }

        /// <summary>
        /// Saves the group to the database
        /// </summary>
        /// <param name="group">The group to add</param>
        /// <returns>The number of rows added</returns>
        public Task<int> SaveGroupAsync(Group group)
        {
            return _database.InsertAsync(group);
        }

        /// <summary>
        /// Deletes the group from the database
        /// </summary>
        /// <param name="group">The group to remove</param>
        /// <returns>The number of rows</returns>
        public Task<int> DeleteGroupAsync(Group group)
        {
            return _database.DeleteAsync(group);
        }
    }
}
