using MauiExample.Database;
using MauiExample.Models;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage(MauiExampleDatabase database)
        {
            InitializeComponent();
            this.BindingContext = new NewItemViewModel(database);
        }
    }
}
