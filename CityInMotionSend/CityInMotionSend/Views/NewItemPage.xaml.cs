<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Views/NewItemPage.xaml.cs
﻿using CityInMotionSend.Models;
using CityInMotionSend.ViewModels;
========
﻿using CityInMotionApp.Models;
using CityInMotionApp.ViewModels;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Views/NewItemPage.xaml.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/Views/NewItemPage.xaml.cs
namespace CityInMotionSend.Views
========
namespace CityInMotionApp.Views
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/Views/NewItemPage.xaml.cs
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}