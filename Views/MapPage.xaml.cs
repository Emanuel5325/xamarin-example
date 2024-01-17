using MauiExample.ViewModels;
using System.ComponentModel;

namespace MauiExample.Views
{
    public partial class MapPage : INotifyPropertyChanged
    {
        public MapPage()
        {
            InitializeComponent();

            this.BindingContext = new MapViewModel();
        }
    }
}