namespace DemoApplication.Controllers.Account
{
    #region

    using System.Web.Mvc;
    using Core.Common.Membership;
    using Core.Common.Membership.Events;
    using Core.Model;
    using Extensions;
    using Filters;
    using Infrastructure.Eventing;
    using Models.Account;
    using Omu.ValueInjecter;

    #endregion

    public partial class AccountController
    {
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

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

                    MessageBus.Instance.Publish(new UserCreated(user, Url.AbsoluteAction("Logon", "Account")));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, ErrorCodeToString(createStatus));
            }

            return View(model);
        }

        private static string ErrorCodeToString(CreateUserStatus createStatus)
        {
            switch (createStatus)
            {
                case CreateUserStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case CreateUserStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";
               
                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }
}