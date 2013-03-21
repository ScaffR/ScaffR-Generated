#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-04-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Components
{
    #region

    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// Class ComponentsController
    /// </summary>
    public partial class ComponentsController
    {
        /// <summary>
        /// Landing page for the components section of the website.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

    }
}
