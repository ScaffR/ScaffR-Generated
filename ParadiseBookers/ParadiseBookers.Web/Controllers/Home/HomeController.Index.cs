#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;
using ParadiseBookers.Filters;

namespace ParadiseBookers.Controllers.Home
{
    #region

    

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
            return View("Dashboard");
        }

    }
}