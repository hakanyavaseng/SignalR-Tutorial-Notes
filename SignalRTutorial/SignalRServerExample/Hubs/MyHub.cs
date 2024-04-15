using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Interfaces;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub<IMessageClient> //Name convention
    {
        private static List<string> clients = new();
        public async Task SendMessageAsync(string message)
        {
            //await Clients.All.SendAsync("receiveMessage", message); // Clients property comes with Hub base class, All sends the message to all connected clients.
        }

        // It is called when a client connected to hub
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            // await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userJoined", Context.ConnectionId);
            
            // Strongly typed hubs
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);

        }

        // It is called when a client is disconnected from hub
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("clients", clients);
            //await Clients.All.SendAsync("userLeft", Context.ConnectionId);

            // Strongly typed hubs
            await Clients.All.Clients(clients);
            await Clients.All.UserLeft(Context.ConnectionId);
        }
    }
}
