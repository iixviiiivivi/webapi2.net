using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using webapi2.Filters;
using webapi2.Filters.Actions;

namespace webapi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {  
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Formatters Setting
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Exception Filter Setting
            config.Filters.Add(new ExceptionHandlerAttribute());
            // Action Filter Setting
            config.Filters.Add(new ActionInfoAttribute());
            // Enable Cors
            config.EnableCors();
        }
    }
}
