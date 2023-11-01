using Microsoft.AspNet.SignalR;

namespace DiscussionForum
{
    public class NotificationHub : Hub
    {
        public static void SendNotification(string userId, string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.User(userId).notify(message);
        }
    }
}