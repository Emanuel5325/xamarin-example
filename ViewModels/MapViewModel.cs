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

        private string SetButtonText() => this.ButtonText = this.IsPaused ? PLAY : PAUSE;
    }
}
