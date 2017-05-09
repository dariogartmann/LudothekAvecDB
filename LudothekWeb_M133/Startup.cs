using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LudothekAvecDB.Startup))]
namespace LudothekAvecDB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
