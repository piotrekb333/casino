using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Casino.Startup))]
namespace Casino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
