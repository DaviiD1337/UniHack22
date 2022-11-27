using CityInMotionApp.UserInfo;
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
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace CityInMotionSend.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        HubConnection hubConnection;
        Item pastItem;
       
        public ItemsPage()
        {

            InitializeComponent();
            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.35.200/movehub").Build();
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

               /* if (hubConnection.State == HubConnectionState.Connected)
                {
                    int vote = 0;
                    for (int i = 0; i < MockDataStore.items.Count; i++)
                    {
                        if (MockDataStore.items[i].Text == ItemsViewModel.title)
                        {
                            vote = MockDataStore.items[i].Rating;
                            
                        }
                    }


                }*/

                hubConnection.On<string, string, string, int>("ReceiveNewPosition", (Titlu, Description, Location,Rating) =>
                    {

                        Item newItem = new Item()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Text = Titlu,
                            Description = Description,
                            Location = Location,
                            Rating = Rating
                        };
                        int ok = 1;
                        for (int i = 0; i < MockDataStore.items.Count; i++)
                        {
                            if (MockDataStore.items[i].Text == newItem.Text)
                                ok = 0;
                        }
                        if (ok == 1 && newItem.Description != "no")
                        {
                            MockDataStore.items.Add(newItem);

                        }
                        else if (newItem.Description == "no")
                        {
                            for (int i = 0; i < MockDataStore.items.Count; i++)
                            {
                                if (MockDataStore.items[i].Text == newItem.Text)
                                {
                                    if(MockDataStore.items[i].Rating > 1)
                                          MockDataStore.items[i].Rating++;
                                }
                            }
                        }
                    



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