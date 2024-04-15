using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Hubs;

namespace SignalRServerExample.Business
{
    public class MyBusiness
    {
        IHubContext<MyHub> hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        
        // To do business logic IHubContext interface can be used.
        public async Task SendMessageAsync(string message)
        {
            await hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
        


    }
}
