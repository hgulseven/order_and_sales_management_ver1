namespace Order_And_Sales_Management_ver1.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;
    public class RefreshSignalHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}