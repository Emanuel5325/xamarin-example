using MauiExample.Models;

namespace MauiExample.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;

        public NewItemViewModel()
        {
            this.SaveCommand = new Command(OnSave, ValidateSave);
            this.CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => this.SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave() =>
            !string.IsNullOrWhiteSpace(this.text) && !string.IsNullOrWhiteSpace(this.description);

        public string Text
        {
            get => this.text;
            set => SetProperty(ref this.text, value);
        }

        public string Description
        {
            get => this.description;
            set => SetProperty(ref this.description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel() =>
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");

        private async void OnSave()
        {
            Item newItem =
                new()
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = this.Text,
                    Description = this.Description
                };

            await this.DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
