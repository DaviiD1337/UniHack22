using CityInMotionApp.UserInfo;
using CityInMotionSend.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

namespace CityInMotionSend.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
       

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        string userLocation;
        string userCnp;
        public string UserCnp
        {
            get => userCnp;
            set
            {
                if(userCnp == value)
                    return;
                userCnp = value;
                OnCnpChanged(nameof(UserCnp));
            }
        }
        public string UserLocation
        {
            get => userLocation;
            set
            {
                if (userLocation == value)
                    return;
                userLocation = value;
                OnLocationChanged(nameof(userLocation));
            }
        }
        public void OnCnpChanged(string userCnp)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(userCnp));
        }
        public void OnLocationChanged(string userLocation)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(userLocation));
        }


        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            UserData.userCnp = UserCnp;
            UserData.Userlocation = UserLocation;
            await App.Current.MainPage.DisplayAlert(" ", "You are logged in", "OK");
        }
    }
}
