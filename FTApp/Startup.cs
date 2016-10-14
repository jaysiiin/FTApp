using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FTApp.Startup))]
namespace FTApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
