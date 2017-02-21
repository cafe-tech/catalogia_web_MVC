using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Catalogia_WebMVC.Startup))]
namespace Catalogia_WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
