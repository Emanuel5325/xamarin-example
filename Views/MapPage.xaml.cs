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
            _ = LoadMapAsync();

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

        private void Send_Clicked(object sender, EventArgs e) => SetItemMuestra();

        public void SetItemMuestra()
        {
            newMarker("-2.14003", "-79.9312967", "Soy un marker");

            newCircle("-2.1407283", "-79.9286524", "red", "#07", 0.5, 50);

            newLine("-2.14003", "-79.9312967", "-2.1407283", "-79.9286524", "blue");

            Show();

            CentrarMapa("-2.14003", "-79.9312967");
        }
        public void newMarker(string lat, string lon, string texto = "")
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }

            this.webView.Eval(string.Format("newMarker({0}, {1}, {2})", "\"" + lat + "\"", "\"" + lon + "\"", "\"" + texto + "\""));
        }
        public void newCircle(string lat, string lon, string color = "blue", string fillcolor = "#07", double fillopacity = 0.5, int radius = 500)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }
            this.webView.Eval(string.Format("newCircle({0},{1},{2},{3},{4},{5})", "\"" + lat + "\"", "\"" + lon + "\"", "\"" + color + "\"", "\"" + fillcolor + "\"", "\"" + fillopacity + "\"", "\"" + radius + "\""));
        }
        public void newLine(string latFrom, string lonFrom, string latTo, string lonTo, string color = "blue")
        {
            if (string.IsNullOrEmpty(latFrom) || string.IsNullOrEmpty(lonFrom) || string.IsNullOrEmpty(latTo) || string.IsNullOrEmpty(lonTo))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }
            this.webView.Eval($@"newLine(""{latFrom}"",""{lonFrom}"",""{latTo}"",""{lonTo}"",""{color}"")");
        }
        public void Show() => this.webView.Eval(@"show()");

        public void CentrarMapa(string lat, string lon)
        {
            if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lon))
            {
                Console.Write("Verifique los campos lat lon");
                return;
            }
            this.webView.Eval(string.Format("centerMap({0},{1})", "\"" + lat + "\"", "\"" + lon + "\""));
        }
    }
}