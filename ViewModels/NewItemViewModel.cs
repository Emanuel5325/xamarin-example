using MauiExample.Database;
using MauiExample.Models;

namespace MauiExample.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;

        public NewItemViewModel(MauiExampleDatabase database) : base(database)
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
                    //Id = this.DataStore.GetId(),
                    Id = 0,
                    Text = this.Text,
                    Description = this.Description
                };

            //await this.DataStore.AddItemAsync(newItem);
            await this.Database.SaveItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
