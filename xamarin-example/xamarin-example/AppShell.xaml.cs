using ViewModels;
using Xamarin.Forms;
using xamarin_example.ViewModels;
using xamarin_example.Views;

namespace xamarin_example
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
