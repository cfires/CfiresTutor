using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CfiresTutor.UI.Admin.Startup))]
namespace CfiresTutor.UI.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
