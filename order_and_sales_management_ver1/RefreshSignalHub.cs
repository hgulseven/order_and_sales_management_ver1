namespace order_and_sales_management_ver1.Hubs
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