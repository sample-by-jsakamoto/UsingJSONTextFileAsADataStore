using System;
using System.Web.Routing;
using System.Web.Mvc;
using UsingJSONTextFileAsADataStore.Services;

namespace UsingJSONTextFileAsADataStore
{
    public class Global : System.Web.HttpApplication
    {
        public static PeopleStore PeopleStore { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            Global.PeopleStore = new PeopleStore();

            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}