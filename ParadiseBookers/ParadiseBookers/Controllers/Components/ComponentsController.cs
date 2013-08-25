#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-04-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;

namespace ParadiseBookers.Controllers.Components
{
    #region

    

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
