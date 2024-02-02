using MauiExample.Business.Database;
using MauiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiExample.Database
{
    public class MauiExampleContext : DbContext
    {

        public DbSet<Item> Items { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }

        public string DbPath { get; }

        public MauiExampleContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            _ = Environment.GetFolderPath(folder);
            //this.DbPath = Path.Join(path, "blogging.db");
            this.DbPath = Constants.DatabasePath;
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={this.DbPath}");
    }
}