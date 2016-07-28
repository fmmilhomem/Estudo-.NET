using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtivosVIDI.Startup))]
namespace AtivosVIDI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
