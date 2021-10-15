using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace ChatAPI
{
    public class Requestlog : Hub
    {
        public static void PostToClient(string data)
        {
            try
            {
                var chat = GlobalHost.ConnectionManager.GetHubContext("Requestlog");
                if (chat != null)
                    chat.Clients.All.PostToClient(data);
            }
            catch
            {
            }
        }

        public override Task OnConnected()
        {
            ////Console.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected(bool isDisconnected)
        {
            ////Console.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected(isDisconnected));
        }

        public override Task OnReconnected()
        {
            ////Console.WriteLine("Hub OnReconnected {0}\n", Context.ConnectionId);
            return (base.OnReconnected());
        }
    }
}