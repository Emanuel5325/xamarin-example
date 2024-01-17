using MauiExample.Services.Work;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class GetWorkPage : ContentPage
    {
        private IWorkApiClient _workService => DependencyService.Get<IWorkApiClient>();

        [Obsolete]
        public GetWorkPage()
        {
            InitializeComponent();

            // TODO Xamarin.Forms.Device.RuntimePlatform is no longer supported. Use Microsoft.Maui.Devices.DeviceInfo.Platform instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
            this.Padding = Device.RuntimePlatform switch
            {
                Device.iOS => new Thickness(40, 60, 40, 40),
                _ => new Thickness(40),
            };
            this.BindingContext = new GetWorkViewModel();
        }

        private void OnWorksQuantityCompleted(object sender, System.EventArgs e)
        {
            var entry = (Entry)sender;

            ReloadLabels(entry);
        }

        private void OnSearchButtonClicked(object sender, System.EventArgs e) => ReloadLabels(WorksQuantity);

        private void ReloadLabels(Entry entry)
        {
            var entryText = entry.Text;

            if (string.IsNullOrEmpty(entryText))
            {
                return;
            }

            if (int.TryParse(entryText, out var quantity))
            {
                WorkName.Text = "error de casteo de número";
                WorkId.Text = "error de casteo de número";
            }

            const int pageSize = 10;
            var page = quantity % pageSize;

            var work = this._workService.All(page, pageSize).FirstOrDefault();

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
