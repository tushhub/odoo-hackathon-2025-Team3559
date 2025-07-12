using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StackIt.Startup))]
namespace StackIt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
