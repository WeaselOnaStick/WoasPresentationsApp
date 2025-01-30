namespace WoasPresentationsApp.Services
{
    public class HubDataService
    {
        public Dictionary<string,string> usernames = new Dictionary<string,string>();

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
