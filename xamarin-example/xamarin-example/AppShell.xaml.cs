using System;
using System.Collections.Generic;
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
        }

    }
}
