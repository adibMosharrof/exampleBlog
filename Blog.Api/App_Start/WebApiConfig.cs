using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Builder;
using Blog.Models;
using Blog.Models.DTO;
using Blog.Models.Entities;
using Microsoft.Data.Edm;

namespace Blog.Api
{
    using System.Web.Http.Cors;

    using Blog.Models;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // New code: 
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            var cors = new EnableCorsAttribute("*", "*", "*", "DataServiceVersion, MaxDataServiceVersion");
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();

            config.EnableQuerySupport();

            //var builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Post>("Posts");
            //builder.EntitySet<Comment>("Comments");
            //builder.EntitySet<PostDto>("PostDtos");
            //builder.EntitySet<CommentDto>("CommentsDtos");
            //builder.Namespace = "Models.Entities";
            config.Routes.MapODataRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                //batchHandler: new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer),
                model: EdmBuilder.GetEdm<MyDbContextForEdm>()
                //model: builder.GetEdmModel() 
                );
            config.Routes.MapHttpRoute(
                         name: "DefaultApi",
                         routeTemplate: "api/{controller}/{id}",
                         defaults: new { id = RouteParameter.Optional }
                     );
        }
    }
}

namespace Blog.Models.Entities
{
    internal class MyDbContextForEdm : BlogContext { }
}
