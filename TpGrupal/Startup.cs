using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TpGrupal.Startup))]
namespace TpGrupal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
