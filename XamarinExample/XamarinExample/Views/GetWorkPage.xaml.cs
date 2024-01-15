using Models.Work;
using Services.Work;
using System.Linq;
using ViewModels;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace XamarinExample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetWorkPage : ContentPage
    {
        private IWorkApiClient _workService => DependencyService.Get<IWorkApiClient>();

        public GetWorkPage()
        {
            InitializeComponent();

            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
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

            WorkData work = _workService.All(page, pageSize).FirstOrDefault();

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