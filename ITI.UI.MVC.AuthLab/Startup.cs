using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITI.UI.MVC.AuthLab.Startup))]
namespace ITI.UI.MVC.AuthLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
