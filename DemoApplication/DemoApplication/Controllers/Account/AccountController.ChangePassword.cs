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
    using Core.Common.Profiles;
    using Core.Extensions;
    using Extensions.TempDataHelpers;
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
                        
                        TempData.AddSuccessMessage(status.GetDescription());
                        return RedirectToAction("Index", "Home");
                        
                    case ChangePasswordStatus.InvalidPassword:
                        ModelState.AddModelError(string.Empty, status.GetDescription());
                        break;
                    case ChangePasswordStatus.Failure:
                        ModelState.AddModelError(string.Empty, status.GetDescription());
                        break;
                }
            }

            ViewBag.PasswordLength = _membershipSetings.MinimumPasswordLength;
            return View(model);
        }
    }
}
