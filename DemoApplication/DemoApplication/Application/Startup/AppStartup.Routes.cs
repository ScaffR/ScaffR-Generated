namespace DemoApplication.Application.Startup
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public partial class AppStartup
    {
        public static void Routes()
        {
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
