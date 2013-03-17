#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Account
{
    #region

    using System;
    using System.Web.Mvc;
    using Core.Common.Profiles;
    using Extensions;
    using Models.Account;
    using Omu.ValueInjecter;

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
