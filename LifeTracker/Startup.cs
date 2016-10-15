using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LifeTracker.Startup))]
namespace LifeTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
