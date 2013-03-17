namespace DemoApplication.Controllers.Account
{
    #region

    using System.Web;
    using System.Web.Mvc;
    using Core.Common.Membership;
    using Core.Common.Membership.Events;
    using Core.Common.Profiles;
    using Core.Extensions;
    using Filters;
    using Infrastructure.Eventing;
    using Models.Account;

    #endregion

    public partial class AccountController
    {
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Logon()
        {
            return View(new LogOnModel()
                {
                    UserName = "admin",
                    Password = "admin"
                });
        }

        [HttpPost]
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Logon(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AuthenticationStatus status;
                var authResult = _userService.Authenticate(model.UserName, model.Password, out status);
                if (authResult)
                {
                    ((MvcSiteMapProvider.DefaultSiteMapProvider)SiteMap.Provider).Refresh();

                    _authenticationService.SignIn(model.UserName);
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
            MessageBus.Instance.Publish(new UserLoggedOut(UserProfile.Current));

            _authenticationService.SignOut();            
            return RedirectToAction("Index", "Home");
        }       
    }
}