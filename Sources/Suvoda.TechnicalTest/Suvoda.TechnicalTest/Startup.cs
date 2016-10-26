using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Suvoda.TechnicalTest.Startup))]
namespace Suvoda.TechnicalTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
