using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Maui.Controls.Xaml;

using XamarinExample.Models;
using XamarinExample.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace XamarinExample.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}