using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dnd.Startup))]
namespace dnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
