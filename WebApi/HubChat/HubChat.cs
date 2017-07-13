namespace WebApi.HubChat
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using System.Threading.Tasks;

    [HubName("hubchat")]
    [Authorize]
    public class HubChat :Hub
    {
        public override Task OnConnected()
        {
            var user = Context.User;

            return base.OnConnected();
        }

        public void send(string msd)
        {

        }
    }
}