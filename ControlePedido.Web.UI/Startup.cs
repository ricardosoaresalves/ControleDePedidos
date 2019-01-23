using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlePedido.Web.UI.Startup))]
namespace ControlePedido.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
