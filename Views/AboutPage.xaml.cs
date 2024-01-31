using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class AboutPage : ContentPage
    {

        private readonly AboutViewModel _viewModel;

        public AboutPage()
        {
            InitializeComponent();

            this.BindingContext = this._viewModel = new AboutViewModel();
        }
    }
}
