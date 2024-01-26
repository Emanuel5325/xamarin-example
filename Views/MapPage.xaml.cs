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

        private void _viewModel_TrackedRoute_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {

                if (this._viewModel.TrackedRoute.Count > 1)
                {
                    var firstNewLocation = e.NewItems[0] as Location;
                    var startIndex = this._viewModel.TrackedRoute.IndexOf(firstNewLocation);

                    for (var i = startIndex; i < this._viewModel.TrackedRoute.Count; i++)
                    {
                        var locationFrom = this._viewModel.TrackedRoute[i - 1];
                        var locationTo = this._viewModel.TrackedRoute[i];

                        newLine(locationFrom.Latitude.ToString(), locationFrom.Longitude.ToString(),
                            locationTo.Latitude.ToString(), locationTo.Longitude.ToString(),
                            "blue");
                    }
                }
                CenterMap();
            }
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this._viewModel.IsPaused))
            {
                var markerLabel = this._viewModel.IsPaused ? "Final" : "Comienzo";
                var locationTask = GetCurrentLocation();
                locationTask.Wait();

                var location = locationTask.Result;

                newMarker(location.Latitude.ToString(), location.Longitude.ToString(), markerLabel);

                this._viewModel.TrackedRoute.Add(location);
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
            //   PermissionException
            catch (Exception)
            {
                // Unable to get location
            }

            return null;
        }

        private void CenterMap()
        {
            var trackedRoute = this._viewModel.TrackedRoute;

            var averageLatitude = trackedRoute.Sum(location => location.Latitude) / trackedRoute.Count;
            var averageLongitude = trackedRoute.Sum(location => location.Longitude) / trackedRoute.Count;

            CenterMap(averageLatitude.ToString(), averageLongitude.ToString());
        }
    }
}