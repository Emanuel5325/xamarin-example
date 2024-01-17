using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            this.BindingContext = new ItemDetailViewModel();
        }
    }
}
