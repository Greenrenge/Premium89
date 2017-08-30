using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Premium89.Startup))]
namespace Premium89
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
