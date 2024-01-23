using MauiExample.CustomRender;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            this.BindingContext = new MapViewModel();
            _ = CargarMapaAsync();

        }

        public async Task CargarMapaAsync()
        {
            var baseUrl = new BaseUrl();
            var source = new HtmlWebViewSource
            {
                BaseUrl = baseUrl.Get()
            };
            //var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            //_ = assembly.GetManifestResourceNames();

            //var stream = assembly.GetManifestResourceStream("LeafletMap.index.html");
            var stream = await FileSystem.OpenAppPackageFileAsync("index.html");

            StreamReader reader = null;
            if (stream != null)
            {
                try
                {
                    reader = new StreamReader(stream);
                    source.Html = reader.ReadToEnd();
                }
                finally
                {
                    reader?.Dispose();
                }
                this.webView.Source = source;
            }
            else
            {
                await DisplayAlert("Aviso!", "error al cargar el mapa...", "entendido");
            }
        }



        // emanuel5325 - agregar la lógica del main page de la prueba de leaflet


        private void Send_Clicked(object sender, EventArgs e)
        {
            //SetItemMuestra();
        }



    }
}