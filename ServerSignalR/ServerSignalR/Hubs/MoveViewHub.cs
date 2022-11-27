using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace ServerSignalR.Hubs
{
    public class MoveViewHub:Hub
    {
   
   
        
        public async Task MoveViewFromServer(string Titlu, string Description, string Location, float Rating)
        {
           // Console.WriteLine("Receive position from Server app:" + newX + "/" + newY);
           await Clients.Others.SendAsync("ReceiveNewPosition", Titlu, Description, Location, Rating);

        }
     
   
       

    }
}
