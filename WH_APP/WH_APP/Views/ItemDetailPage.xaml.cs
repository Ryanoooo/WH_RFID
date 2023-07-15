using System.ComponentModel;
using WH_APP.ViewModels;
using Xamarin.Forms;

namespace WH_APP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}