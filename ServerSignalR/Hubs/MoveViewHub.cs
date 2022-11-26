using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace ServerSignalR.Hubs
{
    public class MoveViewHub:Hub
    {
   
   
        
        public async Task MoveViewFromServer(float newX,float newY)
        {
           // Console.WriteLine("Receive position from Server app:" + newX + "/" + newY);
           await Clients.Others.SendAsync("ReceiveNewPosition", newX, newY);

        }
   
       

    }
}
