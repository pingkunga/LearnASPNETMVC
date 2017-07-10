using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LearnASPNETMVC
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

            //url pattern
            //old style: http://mysite/Products/ShowProductDetails/469
            //seo style: http://mysite/ice-cream/469-Details
            //>> ในตัว seo style ตัว Route วิ่งเข้า Default ที่ Map เข้าไว้กับ Controller และ Action
            routes.MapRoute(
                name: "ProductSEO",
                url: "{name}/{id}-Details",
                defaults: new
                {
                    controller = "Products",
                    action = "ShowProductDetails", id = UrlParameter.Optional }
                );
        }
    }
}
