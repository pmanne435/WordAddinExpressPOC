using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Verisk.ISO.Mozart.Web.Startup))]
namespace Verisk.ISO.Mozart.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
