<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/App.xaml.cs
﻿using CityInMotionSend.Services;
using CityInMotionSend.Views;
========
﻿using CityInMotionApp.Services;
using CityInMotionApp.Views;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Views/App.xaml.cs
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/App.xaml.cs
namespace CityInMotionSend
========
namespace CityInMotionApp
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Views/App.xaml.cs
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
