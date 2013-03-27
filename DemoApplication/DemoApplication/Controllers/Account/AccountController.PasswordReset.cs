#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Core.Services;
    using Extensions.ModelStateHelpers;
    using Filters;
    using Models.Account;

    #endregion

    /// <summary>
    /// Class AccountController
    /// </summary>
    public partial class AccountController
    {
        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, ShowMainMenu(false)]
        public ActionResult PasswordReset()
        {
            return View();
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, HttpPost, ShowMainMenu(false)]
        public ActionResult PasswordReset(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _userService.ResetPassword(model.EmailAddress);
                    if (ModelState.Process(result))
                    {
                        return View("ResetSuccess");
                    }
                    ModelState.AddModelError("", "Error resetting password. The email might be invalid.");

                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (UserNotFoundException ex)
                {
                    ModelState.AddModelError("", "Error resetting password. The email might be invalid.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult ConfirmPasswordReset(string id)
        {
            var vm = new ChangePasswordFromResetKeyModel()
            {
                Key = id
            };
            return View("ConfirmResetPassword", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmPasswordReset(ChangePasswordFromResetKeyModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_userService.ChangePasswordFromResetKey(model.Key, model.Password))
                    {
                        return View("ResetPasswordSuccess");
                    }
                    ModelState.AddModelError("", "Error changing password. The key might be invalid.");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }
    }
}