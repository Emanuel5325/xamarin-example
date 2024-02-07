using MauiExample.Database;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(MauiExampleDatabase database)
        {
            InitializeComponent();
            this.BindingContext = new ItemDetailViewModel(database);
        }
    }
}
