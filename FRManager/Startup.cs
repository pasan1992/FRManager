using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FRManager.Startup))]
namespace FRManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
