using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NestedGridView.Startup))]
namespace NestedGridView
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
