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



        // emanuel5325 - agregar la l�gica del main page de la prueba de leaflet



    }
}