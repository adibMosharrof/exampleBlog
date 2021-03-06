using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Batch;
using Blog.Models.Entities;
using Blog.Models.Repositories;
using Microsoft.Data.Edm;
using Microsoft.Practices.Unity;

namespace Blog.Api.Configurations
{
    public static class AllConfigurations
    {
        public static void ConfigureDependencyInjection(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IPostsRepository, PostsRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }

        public static void ConfigureRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapODataRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                batchHandler: new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer),
                model: EdmBuilder.GetEdm<MyDbContextForEdm>()
                //model: builder.GetEdmModel() 
                );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }

        public static void ConfigureJsonFormatting(HttpConfiguration config)
        {
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }

        public static void ConfigureCors(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*", "DataServiceVersion, MaxDataServiceVersion");
            config.EnableCors(cors);

            config.EnableQuerySupport();
        }
    }
}