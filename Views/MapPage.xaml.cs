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



        // emanuel5325 - agregar la lógica del main page de la prueba de leaflet



    }
}