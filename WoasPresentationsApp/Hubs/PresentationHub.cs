using Blazor.Extensions.Canvas.Canvas2D;
using Excubo.Blazor.Canvas;
using Microsoft.AspNetCore.SignalR;
using WoasPresentationsApp.Services;
using static WoasPresentationsApp.Services.HubDataService;

namespace WoasPresentationsApp.Hubs
{
    public class PresentationHub : Hub
    {
        private readonly HubDataService _hubDataService;

        public PresentationHub(HubDataService hubDataService)
        {
            _hubDataService = hubDataService;
        }

        public async Task UpdateCanvasToEveryoneElse(string callersUsername, string canvasNewURL)
        {
            _hubDataService.canvases[callersUsername] = canvasNewURL;
            await Clients.Others.SendAsync("CanvasUpdated", canvasNewURL);
        }

        public async Task GetCanvasByUsername(string username)
        {
            await Clients.Caller.SendAsync("CanvasByUsername", _hubDataService.canvases.GetValueOrDefault(username, ""));
        }
    }
}
