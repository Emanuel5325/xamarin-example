using MauiExample.Models;

namespace MauiExample.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> items;

        public MockDataStore()
        {
            var i = 0;
            this.items =
            [
                new()
                {
                    Id = i++,
                    Text = "First item",
                    Description = "This is an item description."
                },
                new()
                {
                    Id = i++,
                    Text = "Second item",
                    Description = "This is an item description."
                },
                new()
                {
                    Id = i++,
                    Text = "Third item",
                    Description = "This is an item description."
                },
                new()
                {
                    Id = i++,
                    Text = "Fourth item",
                    Description = "This is an item description."
                },
                new()
                {
                    Id = i++,
                    Text = "Fifth item",
                    Description = "This is an item description."
                },
                new()
                {
                    Id = i++,
                    Text = "Sixth item",
                    Description = "This is an item description."
                }
            ];
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            this.items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = this.items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            _ = this.items.Remove(oldItem);
            this.items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = this.items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            _ = this.items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id) => await Task.FromResult(this.items.FirstOrDefault(s => s.Id == id));

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(this.items);
        public int GetId() => this.items.Max(_ => _.Id) + 1;
    }
}
