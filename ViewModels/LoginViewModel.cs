using MauiExample.Views;

namespace MauiExample.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public LoginViewModel()
        {

            this.LoginCommand = new Command(OnLogin, ValidateLogin);
            PropertyChanged += (_, __) => this.LoginCommand.ChangeCanExecute();
        }

        public Command LoginCommand { get; }

        public async void OnLogin() => await Shell.Current.GoToAsync(nameof(AboutPage));

        private bool ValidateLogin() => true;


    }
}
