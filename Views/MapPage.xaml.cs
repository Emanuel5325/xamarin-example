using MauiExample.CustomRender;
using MauiExample.ViewModels;
using System.Collections.Specialized;
using System.Globalization;

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

            this._viewModel.TrackedRoute.CollectionChanged += _viewModel_TrackedRoute_CollectionChanged;
            this._viewModel.PropertyChanged += _viewModel_PropertyChanged;
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

            await GetCurrentLocation();
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

        public void SetZoom(int zoom) => this.webView.Eval($@"setZoom({zoom.ToString(CultureInfo.InvariantCulture)})");

        private void _viewModel_TrackedRoute_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {

                if (this._viewModel.TrackedRoute.Count > 1)
                {
                    var firstNewLocation = e.NewItems[0] as Location;
                    var startIndex = e.NewItems.Count == this._viewModel.TrackedRoute.Count ?
                        1
                        : this._viewModel.TrackedRoute.IndexOf(firstNewLocation);

                    for (var i = startIndex; i < this._viewModel.TrackedRoute.Count; i++)
                    {
                        var locationFrom = this._viewModel.TrackedRoute[i - 1];
                        var locationTo = this._viewModel.TrackedRoute[i];

                        newLine(locationFrom.Latitude.ToString(CultureInfo.InvariantCulture), locationFrom.Longitude.ToString(CultureInfo.InvariantCulture),
                            locationTo.Latitude.ToString(CultureInfo.InvariantCulture), locationTo.Longitude.ToString(CultureInfo.InvariantCulture),
                            "blue");
                    }
                }
                CenterMap();
            }
        }

        private async void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this._viewModel.IsPaused))
            {
                var markerLabel = this._viewModel.IsPaused ? "Final" : "Comienzo";
                var location = await GetCurrentLocation();

                if (location == null)
                {
                    return;
                }

                newMarker(location.Latitude.ToString(CultureInfo.InvariantCulture), location.Longitude.ToString(CultureInfo.InvariantCulture), markerLabel);

                this._viewModel.TrackedRouteAdd(location);
                CenterMap();
            }
        }

        public async Task<Location> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(MapViewModel.ACCURACY, TimeSpan.FromSeconds(MapViewModel.REFRESH_TIME_IN_SECONDS));

                var location = await Geolocation.Default.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}");
                }
                return location;
            }
            // Catch one of the following exceptions:
            //   FeatureNotSupportedException
            //   FeatureNotEnabledException
            catch (PermissionException)
            {
                return null;
            }
            catch (Exception)
            {
                // Unable to get location
            }

            return null;
        }

        private void CenterMap()
        {
            var trackedRoute = this._viewModel.TrackedRoute;

            var averageLatitude = (trackedRoute.Max(location => location.Latitude) + trackedRoute.Min(location => location.Latitude)) / 2;
            var averageLongitude = (trackedRoute.Max(location => location.Longitude) + trackedRoute.Min(location => location.Longitude)) / 2;

            CenterMap(averageLatitude.ToString(CultureInfo.InvariantCulture), averageLongitude.ToString(CultureInfo.InvariantCulture));
            SetZoom(GetZoomNumber());
        }

        private int GetZoomNumber()
        {
            if (!this._viewModel.TrackedRoute.Any())
            {
                return 4;
            }
            else if (this._viewModel.TrackedRoute.Count == 1)
            {
                return 20;
            }

            // emanuel5325 - pendiente de la generaci�n del c�lculo del zoom
            return 18;
        }
    }
}