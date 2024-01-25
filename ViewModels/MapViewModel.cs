using System.Collections.ObjectModel;

namespace MauiExample.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private const string PAUSE = "Pause";
        private const string PLAY = "Play";

        public MapViewModel()
        {
            this.Title = "Mapa";
            this.IsPaused = true;
            SetButtonText();

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
            set => SetProperty(ref this.isPaused, value, nameof(this.isPaused), TryRecordLocation);
        }

        public void ChangeRecordingState()
        {
            this.IsPaused = !this.IsPaused;
            SetButtonText();
        }
        public Command PlayPauseCommand { get; }

        public ObservableCollection<Location> TrackedRoute = new();


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
                TryStartListeningGeolocation();
            }
        }

        private void TryStopListeningGeolocation()
        {
            //emanuel5325 - tratar de apagar el listener
            var a = 0;
            a++;
            Console.WriteLine(a);
        }

        private void TryStartListeningGeolocation()
        {
            // emanuel5325 - tratar de iniciar el listener con un span de cinco segundos y que este agregue cosas
            // al listado de localizaciones

            var a = 22;
            a++;
            Console.WriteLine(a);
        }

        //async void OnStartListening()
        //{
        //    try
        //    {
        //        Geolocation.LocationChanged += Geolocation_LocationChanged;
        //        var request = new GeolocationListeningRequest((GeolocationAccuracy)Accuracy);
        //        var success = await Geolocation.StartListeningForegroundAsync(request);

        //        string status = success
        //            ? "Started listening for foreground location updates"
        //            : "Couldn't start listening";
        //    }
        //    catch (Exception ex)
        //    {
        //        // Unable to start listening for location changes
        //    }
        //}

        //void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        //{
        //    // Process e.Location to get the new location
        //}

    }
}
