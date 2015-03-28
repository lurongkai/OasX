using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (OasX.Startup))]

namespace OasX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}