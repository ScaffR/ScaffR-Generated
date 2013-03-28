#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-17-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Account
{
    #region

    using System.Web.Mvc;
    using Core.Common.Membership.Events;
    using Infrastructure.Profiles;

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