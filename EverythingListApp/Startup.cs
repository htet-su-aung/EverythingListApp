using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EverythingListApp.Startup))]
namespace EverythingListApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
