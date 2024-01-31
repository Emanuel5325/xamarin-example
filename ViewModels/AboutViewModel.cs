using MauiExample.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiExample.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<WorkInspection> Inspections;

        public AboutViewModel()
        {
            this.Title = "About";
            this.OpenWebCommand = new Command(AddInspection);

            this.Inspections = [];
        }

        public ICommand OpenWebCommand { get; }

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

    }
}
