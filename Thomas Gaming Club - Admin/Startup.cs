using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Thomas_Gaming_Club___Admin.Startup))]
namespace Thomas_Gaming_Club___Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
