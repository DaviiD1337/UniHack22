using CityInMotionApp.UserInfo;
using CityInMotionSend.Services;
using CityInMotionSend.ViewModels;
using Microsoft.AspNetCore.SignalR.Client;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CityInMotionSend.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public static int ok = 1;
     
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

    

        private void Button_Clicked_2(object sender, System.EventArgs e)
        {

            for (int i = 0; i < MockDataStore.items.Count; i++)
            {
                if (MockDataStore.items[i].Text == ItemsViewModel.title && ok == 1)
                {
                    MockDataStore.items[i].Rating = 1;
                    ok = 0;

                }
            }



        }
    }
}