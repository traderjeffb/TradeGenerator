using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradeGenerator.Startup))]
namespace TradeGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
