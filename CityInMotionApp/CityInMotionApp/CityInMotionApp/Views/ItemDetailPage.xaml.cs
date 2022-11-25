using CityInMotionApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CityInMotionApp.Views
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