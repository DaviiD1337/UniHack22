<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/AppShell.xaml.cs
﻿using CityInMotionSend.ViewModels;
using CityInMotionSend.Views;
========
﻿using CityInMotionApp.ViewModels;
using CityInMotionApp.Views;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/AppShell.xaml.cs
using System;
using System.Collections.Generic;
using Xamarin.Forms;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/AppShell.xaml.cs
namespace CityInMotionSend
========
namespace CityInMotionApp
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/AppShell.xaml.cs
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
