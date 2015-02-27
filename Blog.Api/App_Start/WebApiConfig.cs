using System.Web.Http;
using Blog.Api.Configurations;

namespace Blog.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            AllConfigurations.ConfigureJsonFormatting(config);
            AllConfigurations.ConfigureCors(config);
            AllConfigurations.ConfigureRoutes(config);
            AllConfigurations.ConfigureDependencyInjection(config);
        }
    }
}

namespace Blog.Models.Entities
{
    internal class MyDbContextForEdm : BlogContext { }
}
