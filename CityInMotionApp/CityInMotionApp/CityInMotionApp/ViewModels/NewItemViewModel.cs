using CityInMotionApp.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityInMotionApp.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private string location;
        string finalMessage = "messagenotReceived";

        HubConnection hubConnection;

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
            var ip = "localhost";
            if (Device.RuntimePlatform == Device.Android)
                ip = "10.0.2.2";

            hubConnection = new HubConnectionBuilder().WithUrl("http://172.20.10.10:7500/movehub").Build();

            Debug.Print("12" + "/n");
                await hubConnection.StartAsync();
                await hubConnection.InvokeAsync("MoveViewFromServer", "un Titlu oarecare", "ceva", "Timisoara");


            Debug.Print("XXXXXXX"+"/n");

            hubConnection.On<string, string, string>("MoveViewFromServer", (Titlu, Description, location) =>
            {
                Debug.Print($"{Titlu}");
                // Update the UI
            });
            

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
