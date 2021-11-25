using Hospital.Services.Entitties;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital
{
    public class FriendAsyncRepository
    {
        SQLiteAsyncConnection database;

        public FriendAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable<T>() where T : new()
        {
            await database.CreateTableAsync<T>();
        }

        public async Task<List<T>> GetItemsAsync<T>() where T : new()
        {
            return await database.Table<T>().ToListAsync();

        }
        public async Task<T> GetItemAsync<T>(int id) where T : new()
        {
            return await database.GetAsync<T>(id);
        }

        public async Task<int> SaveItemAsyn<T>(T item) where T : IEntity, new()
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
