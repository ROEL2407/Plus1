using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Plus1.Startup))]
namespace Plus1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
