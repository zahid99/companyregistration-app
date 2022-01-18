using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppCompanyRegistration.Startup))]
namespace WebAppCompanyRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
