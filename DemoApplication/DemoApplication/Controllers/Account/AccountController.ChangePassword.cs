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
    using System.Web.Security;
    using Core.Common.Membership;
    using Core.Common.Profiles;
    using Models.Account;

    #endregion

    public partial class AccountController
    {
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult ChangePassword(string username)
        {
            return View();
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var status = _userService.ChangePassword(UserProfile.Current, model.OldPassword, model.NewPassword);

                switch (status)
                {
                    case ChangePasswordStatus.Success:
                        
                        TempData["Success"] = "Password was changed successfully";

                        return Redirect(FormsAuthentication.DefaultUrl);
                        
                    case ChangePasswordStatus.InvalidPassword:
                        ModelState.AddModelError(string.Empty, "The current password is incorrect or the new password is invalid.");
                        break;
                    case ChangePasswordStatus.Failure:
                        ModelState.AddModelError(string.Empty, "An unexpected error occurred.");
                        break;
                }
            }

            ViewBag.PasswordLength = 6; // todo: this should come from a "membership" setting configuration element
            return View(model);
        }
    }
}
