using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MircheeMusicAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//            routes.MapRoute(
//    name: "Book",
//    url: "books/{id}",
//    defaults: new { controller = "users", action = "Details" },
//    constraints: new { productId = @"\d+" }
//);
            //routes.MapRoute(
            //    name: "Tracks",
            //    url: "albums/{id}/tracks",
            //    defaults: new { Controller = "Tracks", action = "GetAllTracksForAlbum" }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
