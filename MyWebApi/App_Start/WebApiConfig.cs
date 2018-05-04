using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Routing;

namespace MyWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //Maps the attribute-defined routes for the application. Enable attrubute routing in order to use attribute routing with the Web API
            config.MapHttpAttributeRoutes();

            //config.Routes is a route table or route collection of type HttpRouteCollection
            //if incomming request url match with SchoolRoute template, so it will be handled by SchoolController
            IHttpRoute SchoolRoute = config.Routes.CreateRoute("api/myschool/{id}", new { controller = "school", id = RouteParameter.Optional }, constraints: new { id = "/d+" });

            //Add route into a collection manually
            config.Routes.Add("School", SchoolRoute);

            //MapHttpRoute is extension method internally creates a new instance of IHttpRoute and add it to an HttpRouteCollection
            //contraints: regex expression to specify characteristic of values route
            //handler: the handler to which the request will be dispatched
            config.Routes.MapHttpRoute(
                name: "DefaultApi", //name of the route
                routeTemplate: "api/{controller}/{id}", //URL pattern of the route, use api here is just to avoid confusion between MVC Controller and API Controller
                defaults: new { id = RouteParameter.Optional } //an object parameter that includes default route parameters
            );

            JsonMediaTypeFormatter jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
