using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CfiresTutor.UI.Web.Startup))]
namespace CfiresTutor.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
