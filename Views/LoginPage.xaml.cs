using MauiExample.ViewModels;

namespace MauiExample.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            this.BindingContext = new LoginViewModel();
        }

    }
}