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

    using System.Web.Mvc;
    using Core.Common.Membership;
    using Core.Common.Membership.Events;
    using Core.Extensions;
    using Core.Model;
    using Extensions.UrlHelpers;
    using Filters;
    using Models.Account;
    using Omu.ValueInjecter;

    #endregion

    /// <summary>
    /// Class AccountController
    /// </summary>
    public partial class AccountController
    {
        /// <summary>
        /// Registration form.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        /// <summary>
        /// Registration form.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost, AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User();

                user.InjectFrom<UnflatLoopValueInjection>(model);
                user.ShowWelcomePage = true;

                CreateUserStatus createStatus = _userService.CreateUser(user);

                if (createStatus == CreateUserStatus.Success)
                {
                    _authenticationService.SignIn(model.Username);

                    _messageBus.Publish(new UserCreated(user, Url.AbsoluteAction("Login", "Account")));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, createStatus.GetDescription());
            }

            return View(model);
        }
    }
}