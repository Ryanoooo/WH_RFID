using System;
using System.Collections.Generic;
using System.ComponentModel;
using WH_APP.Models;
using WH_APP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WH_APP.Views
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