using CityInMotionSend.Services;
using CityInMotionSend.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CityInMotionSend.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            for(int i = 0;i<MockDataStore.items.Count;i++)
            {
                if (MockDataStore.items[i].Text == ItemsViewModel.title)
                {
                    MockDataStore.items[i].rating = 0;
                }
            }
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            for (int i = 0; i < MockDataStore.items.Count; i++)
            {
                if (MockDataStore.items[i].Text == ItemsViewModel.title)
                {
                    MockDataStore.items[i].rating = 1;
                }
            }
        }
    }
}