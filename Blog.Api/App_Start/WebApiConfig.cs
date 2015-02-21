using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;

namespace Blog.Api
{
    using System.Web.Http.Cors;

    using Blog.Models;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var cors = new EnableCorsAttribute("*", "*", "*", "DataServiceVersion, MaxDataServiceVersion");
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Post>("Posts");
            config.Routes.MapODataRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());

        }
    }
}
