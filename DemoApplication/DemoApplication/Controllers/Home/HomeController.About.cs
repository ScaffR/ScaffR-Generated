#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Marko Ilievski
// Created	: 03-27-2013
// 
// Last Modified By : Marko Ilievski
// Last Modified On : 03-27-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Home
{
    #region

    using System.Web.Mvc;
    using Security.Authorization;
    using Filters;

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