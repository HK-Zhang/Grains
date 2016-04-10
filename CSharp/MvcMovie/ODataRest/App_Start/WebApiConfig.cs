using Microsoft.Data.Edm;
using ODataRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Routing;


namespace ODataRest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapODataRoute("ProductOData", "OData", GenerateEdmModel());
            //config.Routes.MapODataRoute("ProductOData", "OData", GenerateEdmModel());

        }
        private static IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");

            return builder.GetEdmModel();
        }
    }
}
