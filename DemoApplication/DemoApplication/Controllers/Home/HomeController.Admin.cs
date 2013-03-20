#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Home
{
    #region

    using System.Web.Mvc;
    using Security.Authorization;

    #endregion

    public partial class HomeController : Controller
    {

        /// <summary>
        /// Landing page for the administrative portion of the website
        /// </summary>
        /// <returns>ActionResult.</returns>
        [ClaimsAuthorize("View", "ManageUsers")]
        public ActionResult Manage()
        {
            return View();
        }
    }
}