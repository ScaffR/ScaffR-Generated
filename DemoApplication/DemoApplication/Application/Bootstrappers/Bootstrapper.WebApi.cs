using DemoApplication.Application.Bootstrappers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Bootstrapper), "WebApi")]

namespace DemoApplication.Application.Bootstrappers
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Routing;

    public partial  class Bootstrapper
	{
        public static void WebApi()
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"\d+" }
            );

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "DefaultApiWithActions",
                routeTemplate: "api/{controller}/{action}"
            );

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                "DefaultApiGet", "api/{controller}", 
                new { action = "Get" }, 
                new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );
            
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                "DefaultApiPost", "api/{controller}", 
                new { action = "Post" }, 
                new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );
            
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                "DefaultApiPut", "api/{controller}", 
                new { action = "Put" }, 
                new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );
            
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                "DefaultApiDelete", "api/{controller}", 
                new { action = "Delete" }, 
                new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );
        }
	}
}