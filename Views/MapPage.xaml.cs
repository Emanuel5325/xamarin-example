using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            this.BindingContext = new MapViewModel();
        }
    }
}