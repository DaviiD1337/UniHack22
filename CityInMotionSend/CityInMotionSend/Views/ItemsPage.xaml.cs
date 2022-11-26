using CityInMotionSend.Models;
using CityInMotionSend.Services;
using CityInMotionSend.ViewModels;
using CityInMotionSend.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CityInMotionSend.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        HubConnection hubConnection;
       
        public ItemsPage()
        {

            InitializeComponent();
            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.54.200/movehub").Build();
            BindingContext = _viewModel = new ItemsViewModel();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(3);

            var timer = new System.Threading.Timer((e) =>
            {
                if (hubConnection.State == HubConnectionState.Disconnected)
                {
                    try
                    {

                        Task.Run(async() => hubConnection.StartAsync());

                    }
                    catch
                    {

                    }
                    Debug.WriteLine("1");
                }
                hubConnection.On<float, float>("ReceiveNewPosition", (newX, newY) =>
                {
                    MockDataStore.items[3].Text = newX.ToString();
                    MockDataStore.items[3].Description = newY.ToString();
                });
            }, null, startTimeSpan, periodTimeSpan);


        }
     

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}