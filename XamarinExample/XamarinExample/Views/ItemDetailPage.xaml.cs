using System.ComponentModel;
using Xamarin.Forms;
using XamarinExample.ViewModels;

namespace XamarinExample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}