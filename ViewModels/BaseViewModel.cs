﻿using MauiExample.Database;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiExample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public MauiExampleDatabase Database;

        public BaseViewModel(MauiExampleDatabase database) => this.Database = database;


        private bool isBusy = false;
        public bool IsBusy
        {
            get => this.isBusy;
            set => SetProperty(ref this.isBusy, value);
        }

        private string title = string.Empty;
        public string Title
        {
            get => this.title;
            set => SetProperty(ref this.title, value);
        }

        protected bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null
        )
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
