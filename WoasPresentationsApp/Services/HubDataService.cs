using Blazor.Extensions.Canvas.Canvas2D;
using Excubo.Blazor.Canvas;

namespace WoasPresentationsApp.Services
{
    public class HubDataService
    {
        public Dictionary<string,string> usernames = new Dictionary<string,string>();

        // UserName : CanvasImageURL
        public Dictionary<string, string> canvases = new Dictionary<string, string>();

        public void AddUser(string connectionID, string username)
        {
            usernames[connectionID] = username;
        }

        public void RemoveUser(string connectionID)
        {
            usernames.Remove(connectionID);
        }

        public List<string> GetUsers()
        {
            return usernames.Select(x => x.Value).ToList();
        }

    }
}
