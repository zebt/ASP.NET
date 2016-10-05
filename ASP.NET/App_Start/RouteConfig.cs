﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); // uruchomienie attribute routingu - nowego sposobu


            /*routes.MapRoute(
                "KsiazkiByReleaseDate",
                "Ksiazki/released/{year}/{month}",
                new {  controller = "Ksiazki", action="ByReleaseDate"},
                new { year=@"2015|2016", month = @"\d{2}"});*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
