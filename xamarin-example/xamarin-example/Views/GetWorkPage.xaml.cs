using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin_example.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetWorkPage : ContentPage
    {
        public GetWorkPage()
        {
            InitializeComponent();

            //StackLayout layout = new StackLayout();
            //layout.Children.Add(new Label
            //{
            //    Text = "Número de Obra desde initialize",
            //    VerticalOptions = LayoutOptions.Center,
            //    HorizontalOptions = LayoutOptions.Center,
            //});
            //layout.Children.Add(new Label
            //{
            //    Text = "Nombre",
            //    VerticalOptions = LayoutOptions.Center,
            //    HorizontalOptions = LayoutOptions.Center,
            //});
            //layout.Children.Add(new Label
            //{
            //    Text = "Id de Obra",
            //    VerticalOptions = LayoutOptions.Center,
            //    HorizontalOptions = LayoutOptions.Center,
            //});

            //Content = layout;

        }
    }
}