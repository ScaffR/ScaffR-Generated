namespace DemoApplication.Controllers.Account
{
    using System.Web;
    using System.Web.Mvc;
    using Core.Common.Membership;
    using Core.Common.Membership.Events;
    using Core.Common.Profiles;
    using Infrastructure.Eventing;
    using Infrastructure.Extensions;
    using Filters;
    using Models.Account;

    public partial class AccountController
    {
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Logon()
        {
            return View(new LogOnModel());
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