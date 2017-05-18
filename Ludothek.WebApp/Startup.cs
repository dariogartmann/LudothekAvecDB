using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ludothek.WebApp.Startup))]
namespace Ludothek.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
