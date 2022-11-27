using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;

namespace WpfDataServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public HubConnection hubConnection;
        public HubConnection hubConnection1;

        string newTitle,newDescription,newLocation;
        int newRating;
        int k = 0;
        public MainWindow()
        {
            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.35.200:7500/movehub").Build();
            hubConnection1 = new HubConnectionBuilder().WithUrl("http://192.168.35.200/movehub").Build();

            InitializeComponent();
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(5);
            dt.Tick += dtTicker;
            dt.Start();
            


        }

        private async void dtTicker(object sender, EventArgs e)
        {
           
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await hubConnection.StartAsync();

                }
                catch
                {

                }
              
              

          
            }
            hubConnection.On<string, string, string,int>("ReceiveNewPosition", ( Titlu,Description,Location,Rating) =>
            {
                newTitle = Titlu;
                newDescription = Description;
                newLocation = Location;
                newRating = Rating;
                Debug.Print(Titlu + " " + Description + " " + Location + " " + newRating);

            });
            if (hubConnection1.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await hubConnection1.StartAsync();

                }
                catch
                {

                }




            }
            if (hubConnection1.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await hubConnection1.StartAsync();

                }
                catch
                {

                }

            }
            if (hubConnection.State == HubConnectionState.Connected)
            {
                if(newDescription != "no")
                  await hubConnection1.SendAsync("MoveViewFromServer", newTitle, newDescription,newLocation, -1);
                else
                    await hubConnection1.SendAsync("MoveViewFromServer", newTitle, newDescription, newLocation, newRating);


            }
        }
    }
}
