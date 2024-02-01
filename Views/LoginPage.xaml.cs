using MauiExample.Database;
using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _viewModel;

        public LoginPage(MauiExampleDatabase database)
        {
            InitializeComponent();

            this.BindingContext = this._viewModel = new LoginViewModel(database);
            this.Title = this._viewModel.Title;
        }

    }
}