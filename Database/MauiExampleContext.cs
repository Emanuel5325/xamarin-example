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
            var path = Environment.GetFolderPath(folder);
            this.DbPath = Path.Join(path, Constants.DatabaseFilename);

            // emanuel5325 - agregar el cambio para que soporte IOS
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Filename={this.DbPath}");
    }
}