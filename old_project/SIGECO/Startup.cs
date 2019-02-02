using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SIGECO.Startup))]
namespace SIGECO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
