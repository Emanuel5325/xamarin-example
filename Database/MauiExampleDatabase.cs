using MauiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiExample.Database
{
    public class MauiExampleDatabase
    {
        //private SqliteConnection Database;
        private MauiExampleContext Database;

        public MauiExampleDatabase()
        {
        }

        private void Init()
        {
            if (this.Database is not null)
            {
                return;
            }

            //this.Database = new SqliteConnection(Constants.DatabasePath, Constants.Flags);
            //_ = await this.Database.CreateTableAsync<Item>();
            //_ = await this.Database.CreateTableAsync<WorkLocation>();

            this.Database = new MauiExampleContext();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            Init();
            return await this.Database.Items.ToListAsync();
        }

        public async Task<Item> GetItemAsync(int id)
        {
            Init();
            return await this.Database.Items.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Item> SaveItem(Item item)
        {
            Init();
            if (item.Id != 0)
            {
                this.Database.Items.Update(item);
            }
            else
            {
                await this.Database.Items.AddAsync(item);
            }

            this.Database.SaveChanges();

            return item;
        }

        public void DeleteItem(Item item)
        {
            Init();
            this.Database.Items.Remove(item);
            this.Database.SaveChanges();
        }



        public async Task<List<WorkLocation>> GetWorkLocationsAsync()
        {
            Init();
            return await this.Database.WorkLocations.ToListAsync();
        }

        public async Task<WorkLocation> SaveLocationAsync(WorkLocation workLocation)
        {
            Init();
            if (workLocation.Id != 0)
            {
                this.Database.WorkLocations.Update(workLocation);
            }
            else
            {
                await this.Database.WorkLocations.AddAsync(workLocation);
            }

            this.Database.SaveChanges();

            return workLocation;
        }

        public void DeleteLocationAsync(WorkLocation workLocation)
        {
            Init();
            this.Database.WorkLocations.Remove(workLocation);
            this.Database.SaveChanges();
        }

    }
}
