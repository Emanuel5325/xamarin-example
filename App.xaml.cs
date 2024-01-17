using MauiExample.Services;
using MauiExample.Services.Work;

namespace MauiExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<IWorkApiClient, WorkApiClient>();
            this.MainPage = new AppShell();
        }
    }
}
