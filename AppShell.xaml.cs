using MauiExample.Views;

namespace MauiExample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
            Routing.RegisterRoute(nameof(GetWorkPage), typeof(GetWorkPage));
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));


            //this.AboutShellContent.Title = new AboutViewModel().Title;
            //this.ItemsShellContent.Title = new ItemsViewModel().Title;
            //this.GetWorkShellContent.Title = new GetWorkViewModel().Title;
            //this.MapShellContent.Title = new MapViewModel().Title;
        }
    }
}
