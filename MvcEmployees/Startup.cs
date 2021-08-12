using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcEmployees.Startup))]
namespace MvcEmployees
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
