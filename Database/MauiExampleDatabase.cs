using MauiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiExample.Database
{
    public class MauiExampleDatabase
    {
        private readonly MauiExampleContext _DbContext;

        public MauiExampleDatabase(MauiExampleContext dbContext) => this._DbContext = dbContext;

        public async Task<List<Item>> GetItemsAsync() => await this._DbContext.Items.ToListAsync();

        public async Task<Item> GetItemAsync(int id) => await this._DbContext.Items.Where(i => i.Id == id).FirstOrDefaultAsync();

        public async Task<Item> SaveItem(Item item)
        {
            if (item.Id != 0)
            {
                this._DbContext.Items.Update(item);
            }
            else
            {
                await this._DbContext.Items.AddAsync(item);
            }

            this._DbContext.SaveChanges();

            return item;
        }

        public void DeleteItem(Item item)
        {
            this._DbContext.Items.Remove(item);
            this._DbContext.SaveChanges();
        }



        public async Task<List<WorkLocation>> GetWorkLocationsAsync() => await this._DbContext.WorkLocations.ToListAsync();

        public async Task<WorkLocation> SaveLocationAsync(WorkLocation workLocation)
        {
            if (workLocation.Id != 0)
            {
                this._DbContext.WorkLocations.Update(workLocation);
            }
            else
            {
                await this._DbContext.WorkLocations.AddAsync(workLocation);
            }

            this._DbContext.SaveChanges();

            return workLocation;
        }

        public void DeleteLocationAsync(WorkLocation workLocation)
        {
            this._DbContext.WorkLocations.Remove(workLocation);
            this._DbContext.SaveChanges();
        }

    }
}
