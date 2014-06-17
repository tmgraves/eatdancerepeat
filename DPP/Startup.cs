using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DPP.Startup))]
namespace DPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
