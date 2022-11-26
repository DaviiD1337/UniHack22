<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/ViewModels/ItemsViewModel.cs
﻿using CityInMotionApp.UserInfo;
using CityInMotionSend.Models;
using CityInMotionSend.Views;
========
﻿using CityInMotionApp.Models;
using CityInMotionApp.UserInfo;
using CityInMotionApp.Views;
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/ViewModels/ItemsViewModel.cs
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/ViewModels/ItemsViewModel.cs
namespace CityInMotionSend.ViewModels
========
namespace CityInMotionApp.ViewModels
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/ViewModels/ItemsViewModel.cs
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;
        public ObservableCollection<Item> Items { get; }
      //  public ObservableCollection<Item> ItemsNotFiltered { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public static string title;

<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/ViewModels/ItemsViewModel.cs
========
     
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/ViewModels/ItemsViewModel.cs
        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
       
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }
     
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            Debug.Print("REFRESH");
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    if(item.Location == UserData.Userlocation)
<<<<<<<< HEAD:CityInMotionSend/CityInMotionSend/ViewModels/ItemsViewModel.cs
                    Items.Add(item);
========
                       Items.Add(item);
>>>>>>>> a32d994572509f769abf1abe44e7e99c67476347:CityInMotionApp/CityInMotionApp/CityInMotionApp/ViewModels/ItemsViewModel.cs
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
            Debug.Print(UserData.Userlocation);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;

        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;
            title = item.Text;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            // This will push the ItemDetailPage onto the navigation stack
            title = item.Text;
            Debug.Print(title);
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}