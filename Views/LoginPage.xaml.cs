using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = this._viewModel = new LoginViewModel();
            this.Title = this._viewModel.Title;
        }

    }
}