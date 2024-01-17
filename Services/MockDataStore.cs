using MauiExample.Models;

namespace MauiExample.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new() { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new() { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new() { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new() { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new() { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new() { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            Item oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            _=items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            Item oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            _=items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}