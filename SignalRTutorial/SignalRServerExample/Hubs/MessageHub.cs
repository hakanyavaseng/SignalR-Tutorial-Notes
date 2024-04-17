using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
        {

            #region Clients
            //Caller : Only sends message again to the client who sends message.
                //await Clients.Caller.SendAsync("receiveMessage", message);

            //All : Sends coming message to all connected clients.
                //await Clients.All.SendAsync("receiveMessage", message);

            //Others : Sends coming message to except sender client.
                //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Customized Hub Methods

            //AllExcept: Belirtilen client'lar hariç bağlı olan tüm client'lara mesajı gönderir.
                //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);

            //Client : Belirtilen client'a mesaj gönderir.
                //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);

            //Clients
                //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);

            //Group : Belirtilen gruptaki client'lara mesaj gönderir. Önce gruplar oluşturulur, daha sonra client'lar gruplara subscribe edilir.
                //await Clients.Group(groupName).SendAsync("receiveMessage", message);

            //GroupExcept : Belirtilen gruptaki belirtilen client'lar dışındaki tüm client'lara mesaj gönderir.
                //await Clients.GroupExcept(groupName, "connectionIdWouldBeHere").SendAsync("receiveMesage", message);

            //Groups : Birden çok gruba mesaj gönderir.
                //await Clients.Groups(IEnumerable<string> groupNames).SendAsync("receiveMessage", message);

            //OthersInGroup : Mesajı gönderen client hariç gruptaki diğer client'lara mesaj gönderir.
                //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);

            //User, Users (Auth, Authorize)

            #endregion

        }
    }
}
