using ViewModels;
using Xamarin.Forms;
using XamarinExample.ViewModels;
using XamarinExample.Views;

namespace XamarinExample
{
    public partial class AppShell : Xamarin.Forms.Shell
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
