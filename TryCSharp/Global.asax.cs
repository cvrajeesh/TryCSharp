using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TryCSharp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "LogOn", // Route name
              "Account/LogOn", // URL with parameters
              new { controller = "Account", action = "LogOn"} // Parameter defaults
              );

            routes.MapRoute(
                "Normal", // Route name
                "{controller}/{action}/{sid}", // URL with parameters
                new {controller = "Home"} // Parameter defaults
                );

               routes.MapRoute(
                "Default", // Route name
                "{sid}", // URL with parameters
                new { controller = "Home", action = "Index", sid = UrlParameter.Optional} // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}