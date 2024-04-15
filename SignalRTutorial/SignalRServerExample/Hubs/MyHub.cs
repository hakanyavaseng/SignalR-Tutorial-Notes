using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub //Name convention
    {
        private static List<string> clients = new();
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message); // Clients property comes with Hub base class, All sends the message to all connected clients.
        }

        // It is called when a client connected to hub
        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        // It is called when a client is disconnected from hub
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userLeft", Context.ConnectionId);
        }
    }
}
