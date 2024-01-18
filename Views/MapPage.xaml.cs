using MauiExample.ViewModels;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Pin = Microsoft.Maui.Controls.Maps.Pin;

namespace MauiExample.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            this.BindingContext = new MapViewModel();

            var map = new Map();
            map.Pins.Add(new Pin()
            {
                Label = "prueba pin",
                Location = new Location(20.737773, -156.333113),
            });
            this.Content = map;
        }
    }
}