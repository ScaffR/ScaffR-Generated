#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Account
{
    #region

    using System.Web.Mvc;
    using Core.Common.Membership;
    using Core.Common.Membership.Events;
    using Core.Common.Profiles;
    using Core.Extensions;
    using Core.Model;
    using Filters;
    using Models.Account;

    #endregion

    /// <summary>
    /// Class AccountController
    /// </summary>
    public partial class AccountController
    {        
        /// <summary>
        /// Logout the existing user.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult LogOff()
        {
            _messageBus.Publish(new UserLoggedOut(UserProfile.Current));

            _authenticationService.SignOut();            
            return RedirectToAction("Index", "Home");
        }       
    }
}