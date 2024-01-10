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

        private void OnWorksQuantityCompleted(object sender, System.EventArgs e)
        {
            Entry entry = (Entry)sender;

            ReloadLabels(entry);
        }

        private void OnSearchButtonClicked(object sender, System.EventArgs e)
        {
            ReloadLabels(WorksQuantity);
        }

        private void ReloadLabels(Entry entry)
        {
            string entryText = entry.Text;

            if (string.IsNullOrEmpty(entryText))
            {
                return;
            }

            WorkName.Text = entryText;
            WorkId.Text = entryText;
        }
    }
}