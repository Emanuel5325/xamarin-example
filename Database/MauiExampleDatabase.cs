using MauiExample.Business.Database;
using MauiExample.Models;
using SQLite;

namespace MauiExample.Database
{
    public class MauiExampleDatabase
    {
        private SQLiteAsyncConnection Database;

        public MauiExampleDatabase()
        {
        }

        private async Task Init()
        {
            if (this.Database is not null)
            {
                return;
            }

            this.Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _ = await this.Database.CreateTableAsync<Item>();
            _ = await this.Database.CreateTableAsync<WorkLocation>();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            await Init();
            return await this.Database.Table<Item>().ToListAsync();
        }

        public async Task<int> SaveItemAsync(Item item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await this.Database.UpdateAsync(item);
            }
            else
            {
                return await this.Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(Item item)
        {
            await Init();
            return await this.Database.DeleteAsync(item);
        }



        public async Task<List<WorkLocation>> GetWorkLocationsAsync()
        {
            await Init();
            return await this.Database.Table<WorkLocation>().ToListAsync();
        }

        public async Task<int> SaveLocationAsync(WorkLocation workLocation)
        {
            await Init();
            if (workLocation.Id != 0)
            {
                return await this.Database.UpdateAsync(workLocation);
            }
            else
            {
                return await this.Database.InsertAsync(workLocation);
            }
        }

        public async Task<int> DeleteLocationAsync(WorkLocation workLocation)
        {
            await Init();
            return await this.Database.DeleteAsync(workLocation);
        }

    }
}
