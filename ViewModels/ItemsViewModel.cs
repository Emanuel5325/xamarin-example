using MauiExample.Models;
using MauiExample.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiExample.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            this.Title = "Browse";
            this.Items = new ObservableCollection<Item>();
            this.LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            this.ItemTapped = new Command<Item>(OnItemSelected);

            this.AddItemCommand = new Command(OnAddItem);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            this.IsBusy = true;

            try
            {
                this.Items.Clear();
                var items = await this.DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    this.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            this.IsBusy = true;
            this.SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => this._selectedItem;
            set
            {
                _ = SetProperty(ref this._selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj) => await Shell.Current.GoToAsync(nameof(NewItemPage));

        private async void OnItemSelected(Item item)
        {
            if (item == null)
            {
                return;
            }

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
