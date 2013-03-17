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
    using Infrastructure.Eventing;
    using Models.Account;

    #endregion

    public partial class AccountController
    {
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Login()
        {
            return View(new LoginModel()
                {
                    UserName = "admin",
                    Password = "admin"
                });
        }

        [HttpPost]
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AuthenticationStatus status;
                User user;
                var authResult = _userService.Authenticate(model.UserName, model.Password, out status, out user);
                if (authResult)
                {                                      
                    _authenticationService.SignIn(model.UserName);

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

        public ActionResult LogOff()
        {
            _messageBus.Publish(new UserLoggedOut(UserProfile.Current));

            _authenticationService.SignOut();            
            return RedirectToAction("Index", "Home");
        }       
    }
}