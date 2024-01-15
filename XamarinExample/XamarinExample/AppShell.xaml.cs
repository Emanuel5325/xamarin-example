using ViewModels;
using XamarinExample.ViewModels;
using XamarinExample.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace XamarinExample
{
    public partial class AppShell : Microsoft.Maui.Controls.Shell
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
