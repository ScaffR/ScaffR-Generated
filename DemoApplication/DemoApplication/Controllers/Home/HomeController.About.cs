#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-27-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Home
{
    #region

    using System.Web.Mvc;
    using Filters;
    using Security.Authorization;

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