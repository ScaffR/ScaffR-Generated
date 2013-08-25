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
using ParadiseBookers.Core.Common.Membership.Events;
using ParadiseBookers.Infrastructure.Profiles;

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
        /// Logout the existing user.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            if (Request.IsAuthenticated)
            {
                _messageBus.Publish(new UserLoggedOut(UserProfile.Current));
                _authenticationService.SignOut();  
                Session.Abandon();
            }
                      
            return RedirectToAction("Index", "Home");
        }       
    }
}