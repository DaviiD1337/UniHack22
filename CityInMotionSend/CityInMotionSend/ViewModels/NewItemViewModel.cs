<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/ViewModels/NewItemViewModel.cs
﻿using CityInMotionSend.Models;
using CityInMotionSend.Services;
using Microsoft.AspNetCore.SignalR.Client;
========
﻿using CityInMotionApp.Models;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/ViewModels/NewItemViewModel.cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/ViewModels/NewItemViewModel.cs
namespace CityInMotionSend.ViewModels
========
namespace CityInMotionApp.ViewModels
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/ViewModels/NewItemViewModel.cs
{
    
    public class NewItemViewModel : BaseViewModel
    {
        HubConnection hubConnection;
        private string text;
        private string description;
        private string location;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

          
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {

            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.54.200/movehub").Build();
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                try
                {

                    await hubConnection.StartAsync();

                }
                catch
                {

                }
            }

            

           if (hubConnection.State ==  HubConnectionState.Connected)
            {
                await hubConnection.SendAsync("MoveViewFromServer", 12, 4);
                
                

            }


          

            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
                Location = Location
            };


            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        
       
    }
}
