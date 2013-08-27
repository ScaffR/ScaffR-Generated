#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-09-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 04-12-2013
// ***********************************************************************
#endregion
#region

using System.Web.Mvc;
using ParadiseBookers.Application.Startup;
using ParadiseBookers.Dropdowns.Filters;
using ParadiseBookers.Filters;

#endregion

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStartup), "ActionFilters")]

namespace ParadiseBookers.Application.Startup
{
    #region

    

    #endregion

    public partial class AppStartup
    {
        /// <summary>
        /// Actions the filters.
        /// </summary>
        public static void ActionFilters()
        {
            GlobalFilters.Filters.Add(new CustomHandleErrorAttribute());
            GlobalFilters.Filters.Add(new CustomAuthorizeAttribute());
            GlobalFilters.Filters.Add(new FillDropDowns());
            GlobalFilters.Filters.Add(new ShowPageHeadingText(true));
            GlobalFilters.Filters.Add(new ShowMainMenu(true));
            GlobalFilters.Filters.Add(new ShowBreadcrumb(false));
            GlobalFilters.Filters.Add(new ShowAlerts(true));
        }
    }
}