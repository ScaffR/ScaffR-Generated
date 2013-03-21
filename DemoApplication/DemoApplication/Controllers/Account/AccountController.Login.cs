#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 03-15-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Account
{
    #region

    using System.Web.Mvc;
    using Core.Common.Membership;
    using Core.Common.Membership.Events;
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
        /// Authenticate user.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Login()
        {
            return View(new LoginModel()
                {
                    UserName = "admin",
                    Password = "admin"
                });
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AuthenticationStatus status; 
                User user;
                if (_userService.Authenticate(model.UserName, model.Password, out status, out user))
                {
                    _authenticationService.SignIn(user, model.RememberMe);

                    _messageBus.Publish(new UserLoggedIn(user));  

                    if (Url.IsLocalUrl(returnUrl))
                    {                       
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", status.GetDescription());
            }
            return View(model);
        }  
    }
}