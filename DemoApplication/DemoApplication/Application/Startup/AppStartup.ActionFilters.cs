#region

using DemoApplication.Application.Startup;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "ActionFilters")]

namespace DemoApplication.Application.Startup
{
    #region

    using System.Web.Mvc;
    using Dropdowns.Filters;
    using Filters;

    #endregion

    public partial class AppStartup
    {
        public static void ActionFilters()
        {
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            GlobalFilters.Filters.Add(new FillDropDowns());
            GlobalFilters.Filters.Add(new ShowMainMenu(true));
            GlobalFilters.Filters.Add(new ShowBreadcrumb(false));
            GlobalFilters.Filters.Add(new ShowAlerts(true));
        }
    }
}