using MauiExample.ViewModels;
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

            AboutShellContent.Title = new AboutViewModel().Title;
            ItemsShellContent.Title = new ItemsViewModel().Title;
            GetWorkShellContent.Title = new GetWorkViewModel().Title;
        }
    }
}
