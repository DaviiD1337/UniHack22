using CityInMotionApp.UserInfo;
using CityInMotionApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CityInMotionApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private void OnLoginClicked(object obj)
        {
            UserData.userCnp = 0;
            UserData.location = "1";
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
           // Routing.RegisterRoute("//CnpPage", typeof(CnpPage));
           // await Shell.Current.GoToAsync($"//{nameof(CnpPage)}");
        }
    }
}
