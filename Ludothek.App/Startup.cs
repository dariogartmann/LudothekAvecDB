using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ludothek.App.Startup))]
namespace Ludothek.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
