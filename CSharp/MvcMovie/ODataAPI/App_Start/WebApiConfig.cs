using Microsoft.OData.Edm;
using ODataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataAPI
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

            config.MapODataServiceRoute("ProductOData", "OData", GenerateEdmModel());

        }
        private static IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");

            return builder.GetEdmModel();
        }

    }
}
