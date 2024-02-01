using MauiExample.Database;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class ItemsPage : ContentPage
    {
        private readonly ItemsViewModel _viewModel;

        public ItemsPage(MauiExampleDatabase database)
        {
            InitializeComponent();

            this.BindingContext = this._viewModel = new ItemsViewModel(database);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this._viewModel.OnAppearing();
        }
    }
}
