using MauiExample.CustomRender;
using MauiExample.ViewModels;
using System.Collections.Specialized;

namespace MauiExample.Views
{
    public partial class MapPage : ContentPage
    {
        private readonly MapViewModel _viewModel;

        public MapPage()
        {
            InitializeComponent();

            this.BindingContext = this._viewModel = new MapViewModel();
            _ = LoadMapAsync();

            this._viewModel.TrackedRoute.CollectionChanged += ReloadMap;
        }

        public async Task LoadMapAsync()
        {
            var baseUrl = new BaseUrl();
            var source = new HtmlWebViewSource
            {
                BaseUrl = baseUrl.Get()
            };
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

        public void SetItemMuestra()
        {
            newMarker("-2.14003", "-79.9312967", "Soy un marker");

            newCircle("-2.1407283", "-79.9286524", "red", "#07", 0.5, 50);

            newLine("-2.14003", "-79.9312967", "-2.1407283", "-79.9286524", "blue");

            Show();

            CenterMap("-2.14003", "-79.9312967");
        }
        public void newMarker(string latitude, string longitude, string markerLabel = "")
        {
            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                return;
            }
            this.webView.Eval($@"newMarker(""{latitude}"", ""{longitude}"", ""{markerLabel}"")");
        }
        public void newCircle(string latitude, string longitude, string color = "blue", string fillcolor = "#07",
            double fillopacity = 0.5, int radius = 500)
        {
            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                return;
            }
            this.webView.Eval($@"newCircle(""{latitude}"",""{longitude}"",""{color}"",""{fillcolor}"",""{fillopacity}"",""{radius}"")");
        }
        public void newLine(string latitudeFrom, string longitudeFrom, string latitudeTo, string longitudeTo, string color = "blue")
        {
            if (string.IsNullOrEmpty(latitudeFrom)
                || string.IsNullOrEmpty(longitudeFrom)
                || string.IsNullOrEmpty(latitudeTo)
                || string.IsNullOrEmpty(longitudeTo))
            {
                return;
            }
            this.webView.Eval($@"newLine(""{latitudeFrom}"",""{longitudeFrom}"",""{latitudeTo}"",""{longitudeTo}"",""{color}"")");
        }
        public void Show() => this.webView.Eval(@"show()");

        public void CenterMap(string latitude, string longitude)
        {
            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
            {
                return;
            }
            this.webView.Eval($@"centerMap(""{latitude}"",""{longitude}"")");
        }

        private void ReloadMap(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Location item in e.NewItems)
                {
                    Console.WriteLine($"Cam bio en la lista de locations, se agreg�: {item.Latitude}, {item.Longitude}");
                }

                // emanuel5325 - ac� recargar todos los elementos del mapa
            }
        }
    }
}