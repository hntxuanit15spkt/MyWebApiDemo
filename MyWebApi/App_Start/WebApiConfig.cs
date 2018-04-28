﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //Maps the attribute-defined routes for the application.
            config.MapHttpAttributeRoutes(); 

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}