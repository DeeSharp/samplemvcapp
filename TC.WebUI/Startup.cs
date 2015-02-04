using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TC.WebUI.Startup))]
namespace TC.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
