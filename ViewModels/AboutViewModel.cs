﻿using MauiExample.Database;
using MauiExample.Models;
using MauiExample.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiExample.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<WorkInspection> Inspections;

        public AboutViewModel(MauiExampleDatabase database) : base(database)
        {
            this.Title = "About";
            this.OpenWebCommand = new Command(AddInspection);
            this.GoToMapCommand = new Command(GoToMap);
            this.GoToGetWorkCommand = new Command(GoToGetWork);
            this.AddInspectionCommand = new Command(GoToNewInspection);

            this.Inspections = [];
        }

        public ICommand OpenWebCommand { get; }
        public ICommand GoToMapCommand { get; }
        public ICommand GoToGetWorkCommand { get; }

        public ICommand AddInspectionCommand { get; }

        private void AddInspection()
        {
            if (this.Inspections.Count % 2 == 1)
            {
                this.Inspections.Add(
                    new WorkInspection
                    {
                        Title = "inspección mapa",
                        inspectionType = InspectionTypes.Map,
                    });
            }
            else
            {
                this.Inspections.Add(
                    new WorkInspection
                    {
                        Title = "inspección cuestionario",
                        inspectionType = InspectionTypes.Questionaire,
                    });
            }
        }

        private async void GoToMap() => await Shell.Current.GoToAsync(nameof(MapPage));
        private async void GoToGetWork() => await Shell.Current.GoToAsync(nameof(GetWorkPage));
        private async void GoToNewInspection() => await Shell.Current.GoToAsync(nameof(ItemsPage));
    }
}
