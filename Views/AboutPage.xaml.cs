using MauiExample.Database;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class AboutPage : ContentPage
    {

        private readonly AboutViewModel _viewModel;

        public AboutPage(MauiExampleDatabase database)
        {
            InitializeComponent();

            this.BindingContext = this._viewModel = new AboutViewModel(database);
        }
    }
}
