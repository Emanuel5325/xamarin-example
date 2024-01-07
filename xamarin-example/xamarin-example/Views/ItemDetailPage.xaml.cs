using System.ComponentModel;
using Xamarin.Forms;
using xamarin_example.ViewModels;

namespace xamarin_example.Views
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