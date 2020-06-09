using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenLeChiBao_Lab456.Startup))]
namespace NguyenLeChiBao_Lab456
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
