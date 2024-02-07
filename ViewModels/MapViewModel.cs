using MauiExample.Database;
using System.Collections.ObjectModel;

namespace MauiExample.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private const string PAUSE = "Pause";
        private const string PLAY = "Play";

        public const GeolocationAccuracy ACCURACY = GeolocationAccuracy.High;
        public const int REFRESH_TIME_IN_SECONDS = 2;

        public MapViewModel(MauiExampleDatabase database) : base(database)
        {
            this.Title = "Mapa";
            this.isPaused = true;
            SetButtonText();
            this.TrackedRoute = [];

            this.PlayPauseCommand = new Command(OnPlayPause, ValidatePlayPause);
            PropertyChanged += (_, __) => this.PlayPauseCommand.ChangeCanExecute();
        }


        private string buttonText = string.Empty;
        public string ButtonText
        {
            get => this.buttonText;
            set => SetProperty(ref this.buttonText, value);
        }

        private bool isPaused = true;
        public bool IsPaused
        {
            get => this.isPaused;
            set => SetProperty(ref this.isPaused, value, nameof(this.IsPaused), TryRecordLocation);
        }

        public void ChangeRecordingState()
        {
            this.IsPaused = !this.IsPaused;
            SetButtonText();
        }

        public Command PlayPauseCommand { get; }

        public ObservableCollection<Location> TrackedRoute { get; }

        public void TrackedRouteAdd(Location location)
        {
            if (this.TrackedRoute.Any()
                && this.TrackedRoute.Last().Equals(location))
            {
                return;
            }

            this.TrackedRoute.Add(location);
        }

        private void OnPlayPause() => ChangeRecordingState();

        private string SetButtonText() => this.ButtonText = this.IsPaused ? PLAY : PAUSE;

        // emanuel5325 - agregar una validación si corresponde
        private bool ValidatePlayPause() => true;

        private void TryRecordLocation()
        {
            if (this.IsPaused)
            {
                TryStopListeningGeolocation();
            }
            else
            {
                _ = TryStartListeningGeolocation();
            }
        }

        private void TryStopListeningGeolocation()
        {
            //emanuel5325 - tratar de apagar el listener

            OnStopListening();


            var a = 0;
            a++;
            Console.WriteLine(a);
        }

        private async Task TryStartListeningGeolocation()
        {
            // emanuel5325 - tratar de iniciar el listener con un span de cinco segundos y que este agregue cosas
            // al listado de localizaciones
            await OnStartListening();

            var a = 22;
            a++;
            Console.WriteLine(a);
        }

        private async Task OnStartListening()
        {
            try
            {
                Geolocation.LocationChanged += Geolocation_LocationChanged;
                var request = new GeolocationListeningRequest(ACCURACY, TimeSpan.FromSeconds(REFRESH_TIME_IN_SECONDS));
                var success = await Geolocation.StartListeningForegroundAsync(request);

                Console.WriteLine(success
                    ? "Started listening for foreground location updates"
                    : "Couldn't start listening");
            }
            catch (Exception)
            {
                // emanuel5325 - tal vez acá se debería poner en false el flag de ispaused
                // Unable to start listening for location changes
            }
        }

        private void OnStopListening()
        {
            try
            {
                Geolocation.LocationChanged -= Geolocation_LocationChanged;
                Geolocation.StopListeningForeground();
                Console.WriteLine("Stopped listening for foreground location updates");
            }
            catch (Exception)
            {
                // emanuel5325 - tal vez acá se debería poner en false el flag de ispaused
                // Unable to stop listening for location changes
            }
        }

        private void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            TrackedRouteAdd(e.Location);
            Console.WriteLine($"cambio de posición a: {e.Location.Latitude}, {e.Location.Longitude}");
        }
    }
}
