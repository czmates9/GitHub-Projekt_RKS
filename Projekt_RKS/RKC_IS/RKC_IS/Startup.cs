using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RKC_IS.Startup))]
namespace RKC_IS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
