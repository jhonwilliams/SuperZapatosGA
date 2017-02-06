using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperZapatos.Web.Startup))]
namespace SuperZapatos.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
