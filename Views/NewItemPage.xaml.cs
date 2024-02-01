using MauiExample.Business.Models;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            this.BindingContext = new NewItemViewModel();
        }
    }
}
