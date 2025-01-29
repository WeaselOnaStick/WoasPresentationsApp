using Microsoft.AspNetCore.SignalR;

namespace WoasPresentationsApp.Hubs
{
    public class PresentersHub : Hub
    {
        public async Task NewUserReport(string name)
        {
            await Clients.All.SendAsync("NewMessage", $"Everyone welcome {name}!");
        }
    }
}
