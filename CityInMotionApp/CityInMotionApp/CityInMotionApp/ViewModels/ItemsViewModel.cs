using CityInMotionApp.Models;
using CityInMotionApp.UserInfo;
using CityInMotionApp.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CityInMotionApp.ViewModels
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
            Debug.Print("REFRESH" + "/n");
           
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    if(item.Location == UserData.Userlocation)
                       Items.Add(item);
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