<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Views/LoginPage.xaml.cs
﻿using CityInMotionSend.ViewModels;
========
﻿using CityInMotionApp.ViewModels;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Views/LoginPage.xaml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Views/LoginPage.xaml.cs
namespace CityInMotionSend.Views
========
namespace CityInMotionApp.Views
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Views/LoginPage.xaml.cs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}