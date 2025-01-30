using Microsoft.AspNetCore.SignalR;
using WoasPresentationsApp.Services;

namespace WoasPresentationsApp.Hubs
{
    public class PresentersHub : Hub
    {
        private readonly HubDataService _hubDataService;

        public PresentersHub(HubDataService hubDataService)
        {
            _hubDataService = hubDataService;
        }

        public async Task NewUserReport(string name)
        {
            if (_hubDataService.usernames.ContainsValue(name)) return;
            _hubDataService.AddUser(Context.ConnectionId, name);
            await Clients.All.SendAsync("NewMessage", $"Everyone welcome {name}!");
            await Clients.All.SendAsync("ListOfUsers", _hubDataService.GetUsers());
        }

        public async Task Announce(string message)
        {
            await Clients.All.SendAsync("NewMessage", message);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _hubDataService.RemoveUser(Context.ConnectionId);
            await Clients.All.SendAsync("ListOfUsers", _hubDataService.GetUsers());
        }

        public async Task GetListOfUsers()
        {
            await Clients.Caller.SendAsync("ListOfUsers", _hubDataService.GetUsers());
        }
    }
}
