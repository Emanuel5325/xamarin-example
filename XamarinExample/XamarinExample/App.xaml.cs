using Services.Work;
using XamarinExample.Services;
using XamarinExample.Services.Work;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace XamarinExample
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IWorkApiClient, WorkApiClient>();
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
