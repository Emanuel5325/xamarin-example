using System.Diagnostics;

namespace MauiExample.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string text;
        private string description;
        public int Id { get; set; }

        public string Text
        {
            get => this.text;
            set => SetProperty(ref this.text, value);
        }

        public string Description
        {
            get => this.description;
            set => SetProperty(ref this.description, value);
        }

        public int ItemId
        {
            get => this.itemId;
            set
            {
                this.itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                //var item = await this.DataStore.GetItemAsync(itemId);
                var item = await this.Database.GetItemAsync(itemId);
                this.Id = item.Id;
                this.Text = item.Text;
                this.Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
