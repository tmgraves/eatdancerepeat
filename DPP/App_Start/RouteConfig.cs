using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DPP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Users",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Events",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Events", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Places",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Places", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
