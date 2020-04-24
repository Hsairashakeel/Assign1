using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace webAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.EnableCors();
            config.MapHttpAttributeRoutes();
            // Web API configuration and services

            // Web API routes

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
