using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(ChatAPI.Startup))]
namespace ChatAPI{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}