using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hdnug.Web.Startup))]
namespace Hdnug.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
