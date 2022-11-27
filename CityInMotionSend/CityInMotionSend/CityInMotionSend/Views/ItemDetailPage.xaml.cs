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
     
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
        HubConnection hubConnection;


        private void Button_Clicked_2(object sender, System.EventArgs e)
        {
            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.35.200/movehub").Build();
            for (int i = 0; i < MockDataStore.items.Count; i++)
            {
                if (MockDataStore.items[i].Text == ItemsViewModel.title)
                {
                    if (MockDataStore.items[i].Rating != 1) {
                        MockDataStore.items[i].Rating = 1;

                        if (hubConnection.State == HubConnectionState.Connected)
                        {
                             hubConnection.SendAsync("MoveViewFromServer", ItemsViewModel.title, "no", "no", 1);



                        }
                    }





                }
            }



        }
    }
}