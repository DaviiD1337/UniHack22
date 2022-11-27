using CityInMotionApp.UserInfo;
using CityInMotionSend.Models;
using CityInMotionSend.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInMotionSend.ViewModels
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
                && !String.IsNullOrWhiteSpace(description)
                 && !String.IsNullOrWhiteSpace(location)
                && ( UserData.userCnp == "123456789" || UserData.userCnp == "987654321" );
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

            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.35.200:7500/movehub").Build();
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
                await hubConnection.SendAsync("MoveViewFromServer", Text, Description, Location, -1);
                
                

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
