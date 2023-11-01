using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DiscussionForum.Startup))]

namespace DiscussionForum
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure SignalR
            app.MapSignalR();
        }
    }
}