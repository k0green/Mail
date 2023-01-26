using Microsoft.AspNetCore.SignalR;

namespace Mail.Utils
{
    public class ChatHub : Hub
    {
        public async Task Send(string title, string message, string to, string from)
        {
            if (from != to)
                await Clients.User(from).SendAsync("Receive", message, from);
            await Clients.User(to).SendAsync("Receive", message, from);
        }
    }
}
