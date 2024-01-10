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

            TextAlignment labelAlignment = TextAlignment.Start;
            layout.Children.Add(new Label
            {
                Text = "Número de Obra desde initialize",
                HorizontalTextAlignment = labelAlignment,
            });
            layout.Children.Add(new Label
            {
                Text = "Nombre",
                HorizontalTextAlignment = labelAlignment,
            });
            layout.Children.Add(new Label
            {
                Text = "Id de Obra",
                HorizontalTextAlignment = labelAlignment,
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