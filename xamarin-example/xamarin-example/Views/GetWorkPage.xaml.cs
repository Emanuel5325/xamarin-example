using Services.Work;
using System.Threading.Tasks;
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

            _=ReloadLabels(entry);
        }

        private void OnSearchButtonClicked(object sender, System.EventArgs e)
        {
            _=ReloadLabels(WorksQuantity);
        }

        private async Task ReloadLabels(Entry entry)
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

            global::Models.Work.ApiRequestResult<global::Models.Work.WorkData> work = await _workService.All(page, pageSize);

            if (work.HasError)
            {
                WorkName.Text = "error de servicio";
                WorkId.Text = "error de servicio";
            }

            WorkName.Text = work.Data.Name;
            WorkId.Text = work.Data.Id.ToString();
        }
    }
}