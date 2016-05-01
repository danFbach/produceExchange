using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProduceExchange.Startup))]
namespace ProduceExchange
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
