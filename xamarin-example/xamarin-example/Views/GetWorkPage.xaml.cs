using Services.Work;
using ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin_example.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetWorkPage : ContentPage
    {
        private IWorkApiClient _workService => DependencyService.Get<IWorkApiClient>();

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
            // emanuel5325 - esto tiene que llamar al llamado a la API

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