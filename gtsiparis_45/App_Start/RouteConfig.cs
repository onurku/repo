﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace gtsiparis_45
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
               name: "UrunListesi",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Genel", action = "UrunListesi", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                "SiparisiSepeteEkle",
                "SepeteEkle/{id}/{SipMik:decimal}/",
                new
                {
                    controller = "Genel",
                    action = "SiparisiSepeteEkle",
                    id = UrlParameter.Optional,
                    SipMik = UrlParameter.Optional
                });
        }
    }
}
