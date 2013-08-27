#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Web.Mvc;

namespace ParadiseBookers.Controllers.Account
{
    #region

    

    #endregion

    /// <summary>
    /// Class AccountController
    /// </summary>
    public partial class AccountController
    {
        /// <summary>
        /// List's the current user's claims.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Claims()
        {
            return View();
        }

    }
}
