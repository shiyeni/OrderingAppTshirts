using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using T_ShirtApp;

namespace OrderAppTshirt
{
   public class DatabaseTshirts
    {
         readonly SQLiteAsyncConnection database;
        public DatabaseTshirts(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Orders>().Wait();
        }
        public Task<List<Orders>> GetItemsAsync()
        {
            return database.Table<Orders>().ToListAsync();
        }
        public Task<List<Orders>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Orders>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }
        public Task<Orders> GetItemAsync(int id)
        {
            return database.Table<Orders>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(Orders item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(Orders item)
        {
            return database.DeleteAsync(item);

        }
    }
}
