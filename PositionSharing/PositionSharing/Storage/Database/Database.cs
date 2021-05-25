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
        }

        public Task<List<Group>> GetGroupAsync()
        {
            return _database.Table<Group>().ToListAsync();
        }

        public Task<int> SaveGroupAsync(Group group)
        {
            return _database.InsertAsync(group);
        }
    }
}
