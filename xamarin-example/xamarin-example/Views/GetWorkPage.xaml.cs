using Models.Work;
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

            BindingContext = new GetWorkViewModel();
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

            if (int.TryParse(entryText, out int quantity))
            {
                WorkName.Text = "error de casteo de número";
                WorkId.Text = "error de casteo de número";
            }

            const int pageSize = 10;
            int page = quantity % pageSize;

            WorkData work = _workService.All(page, pageSize);

            if (work == null)
            {
                WorkName.Text = "error de servicio";
                WorkId.Text = "error de servicio";
            }

            WorkName.Text = work.Name;
            WorkId.Text = work.Id.ToString();
        }
    }
}