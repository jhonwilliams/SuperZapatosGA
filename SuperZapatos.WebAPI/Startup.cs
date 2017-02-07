using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SuperZapatos.WebAPI.Startup))]

namespace SuperZapatos.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
