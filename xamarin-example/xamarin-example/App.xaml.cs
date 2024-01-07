using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_example.Services;
using xamarin_example.Views;

namespace xamarin_example
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
