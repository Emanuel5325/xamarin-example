using MauiExample.ViewModels;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace MauiExample.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            this.BindingContext = new MapViewModel();

            var map = new Map();
            this.Content = map;
        }
    }
}