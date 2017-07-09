using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LikeSport.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            // Trang chủ
            routes.MapRoute(
            name: "Home",
            url: "Trang-chu",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            // Tìm kiếm
            routes.MapRoute(
            name: "Search",
            url: "Tim-kiem/{text}",
            defaults: new { controller = "Home", action = "Search", text = UrlParameter.Optional }
            );
            // Đăng nhập
            routes.MapRoute(
            name: "Loggin",
            url: "Dang-nhap",
            defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );
            // Trang chủ admin
            routes.MapRoute(
            name: "Admin Index",
            url: "Quan-ly-website-ban-do-the-thao/",
            defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );

            // Mặc định
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
