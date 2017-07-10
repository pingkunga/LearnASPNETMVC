using LearnASPNETMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearnASPNETMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<ShopFactory>(new DropCreateDatabaseAlways<ShopFactory>());

            //// Forces initialization of database on model changes.
            //using (var context = new ShopFactory())
            //{
            //    context.Database.Initialize(force: true);
            //}

            //Database.SetInitializer <GarageFactory>(new DropCreateDatabaseAlways<GarageFactory>());

            //// Forces initialization of database on model changes.
            //using (var context = new GarageFactory())
            //{
            //    context.Database.Initialize(force: true);
            //}
        }
    }
}
