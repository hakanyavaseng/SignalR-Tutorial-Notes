using Microsoft.AspNetCore.SignalR; // Comes with .NET Core as default

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub //Name convention
    {
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message); // Clients property comes with Hub base class, All sends the message to all connected clients.
        }
    }
}
