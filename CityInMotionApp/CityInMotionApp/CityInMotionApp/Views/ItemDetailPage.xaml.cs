using CityInMotionApp.Services;
using CityInMotionApp.UserInfo;
using CityInMotionApp.ViewModels;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
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

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            for (int i = 0; i < MockDataStore.items.Count; i++)
            {
                if (MockDataStore.items[i].Text == ItemsViewModel.title)
                {
                    MockDataStore.items[i].Rating = 0;
                }

            }
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            for (int i = 0; i < MockDataStore.items.Count; i++)
            {
                if (MockDataStore.items[i].Text == ItemsViewModel.title)
                {
                    MockDataStore.items[i].Rating = 1;
                }

            }
            for (int i = 0; i < MockDataStore.items.Count; i++)
            {
                Debug.Print(MockDataStore.items[i].Text + " " + MockDataStore.items[i].Rating + ",") ;

            }

        }
    }
}