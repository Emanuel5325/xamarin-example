using ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin_example.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetWorkPage : ContentPage
    {
        private readonly GetWorkViewModel _viewModel;

        public GetWorkPage()
        {
            InitializeComponent();

            StackLayout layout = new StackLayout();
            layout.Children.Add(new Label
            {
                Text = "Número de Obra desde initialize",
            });
            layout.Children.Add(new Label
            {
                Text = "Nombre",
            });
            layout.Children.Add(new Label
            {
                Text = "Id de Obra",
            });

            Content = layout;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(40, 60, 40, 40);
                    break;
                default:
                    Padding = new Thickness(40);
                    break;
            }

            BindingContext = _viewModel =  new GetWorkViewModel();
        }
    }
}