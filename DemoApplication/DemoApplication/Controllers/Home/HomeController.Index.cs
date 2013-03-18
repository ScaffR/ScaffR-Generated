#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Home
{
    #region

    using System.Web.Mvc;
    using Filters;

    #endregion

    public partial class HomeController
    {
        /// <summary>
        /// Home page.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, ShowMainMenu(false)]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View("Dashboard");
            }
            return View();
        }

    }
}