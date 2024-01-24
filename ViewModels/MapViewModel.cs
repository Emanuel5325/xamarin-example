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
        }



        private string buttonText = string.Empty;
        public string ButtonText
        {
            get => this.buttonText;
            set => SetProperty(ref this.buttonText, value);
        }

        public bool IsPaused { get; set; }

        public void ChangeButtonText()
        {
            this.IsPaused = !this.IsPaused;
            SetButtonText();
        }
        public Command PlayPauseCommand { get; }


        private void OnPlayPause() => ChangeButtonText();

        private string SetButtonText() => this.ButtonText = this.IsPaused ? PLAY : PAUSE;

        private bool ValidatePlayPause() => true;

    }
}
