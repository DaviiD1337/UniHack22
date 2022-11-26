using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/ViewModels/AboutViewModel.cs
namespace CityInMotionSend.ViewModels
========
namespace CityInMotionApp.ViewModels
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/ViewModels/AboutViewModel.cs
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}