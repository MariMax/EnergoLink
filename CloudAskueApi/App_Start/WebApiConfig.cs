using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CloudAskueApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GetSchemes",
                routeTemplate: "api/XCalculator/GetSchemes",
                defaults: new { action = "GetSchemes" }
            );
            config.Routes.MapHttpRoute(
                name: "GetCalcResult",
                routeTemplate: "api/XCalculator/GetCalcResult",
                defaults: new { action = "GetCalcResult" }
            );
            config.Routes.MapHttpRoute(
                name: "Calc",
                routeTemplate: "api/XCalculator/Calc",
                defaults: new { action = "Calc" }
            );
        }
    }
}
