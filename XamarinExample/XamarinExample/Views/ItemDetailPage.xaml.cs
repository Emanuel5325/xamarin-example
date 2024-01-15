using System.ComponentModel;
using XamarinExample.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

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