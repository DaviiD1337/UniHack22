using CityInMotionApp.UserInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CityInMotionApp.UserInfo;
using CityInMotionApp.Views;
using Xamarin.Forms;

namespace CityInMotionApp.ViewModels
{
    class Bindings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string userLocation;
        string userCnp;

        public string UserCnp
        {
            get => userCnp;
            set
            {
                if (userCnp == value)
                {
                    return;
                }
                userCnp = value;
                OnCnpChanged(nameof(UserCnp));
               
            }
        }
        UserData userData = new UserInfo.UserData();
      
        public void OnCnpChanged(string userCnp)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(userCnp));
            
        }
        public void OnLcationChanged(string userLocation)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(userLocation));
        }
     
    }
}
