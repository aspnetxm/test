using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Galaxy.Web.Startup))]
namespace Galaxy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
