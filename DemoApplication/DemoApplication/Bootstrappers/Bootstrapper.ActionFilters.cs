using DemoApplication.Bootstrappers;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Bootstrapper), "ActionFilters")]

namespace DemoApplication.Bootstrappers
{
    using System.Web.Mvc;
    using Filters;

    public partial class Bootstrapper
    {
        public static void ActionFilters()
        {
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            GlobalFilters.Filters.Add(new UserContextFilter());
            //GlobalFilters.Filters.Add(new FillDropDowns());
            GlobalFilters.Filters.Add(new ShowBreadcrumb(false));
            GlobalFilters.Filters.Add(new ShowAlerts(true));
        }
    }
}