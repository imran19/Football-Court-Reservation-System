using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FCRS.Startup))]
namespace FCRS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
