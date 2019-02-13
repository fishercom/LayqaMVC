using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Layqa.Web.Startup))]
namespace Layqa.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
