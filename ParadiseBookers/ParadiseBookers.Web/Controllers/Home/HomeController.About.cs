#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-27-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;
using ParadiseBookers.Filters;
using ParadiseBookers.Security.Authorization;

namespace ParadiseBookers.Controllers.Home
{
    #region

    

    #endregion

    public partial class HomeController
    {
        /// <summary>
        /// About page.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult About()
        {
            return View();
        }
    }
}