using MauiExample.ViewModels;

namespace MauiExample
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            AboutShellContent.Title = new AboutViewModel().Title;
            ItemsShellContent.Title = new ItemsViewModel().Title;
            GetWorkShellContent.Title = new GetWorkViewModel().Title;
        }
    }
}
