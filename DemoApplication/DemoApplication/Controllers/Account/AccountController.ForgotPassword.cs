#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Account
{
    #region

    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Extensions.ModelStateHelpers;
    using Extensions.TempDataHelpers;
    using Extensions.UrlHelpers;
    using Mailers;
    using Models.Account;
    using Mvc.Mailer;

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
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// Forgot the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // lookup user by username...
                var user = _userService.Find(u => model.EmailAddress == u.Email).FirstOrDefault();

                if (user == null)
                {
                    ModelState.AddModelError("", "There is no user with this email address");
                }
                else
                {
                    var temp = Guid.NewGuid().ToString().Substring(0, 8);

                    //user.ResetPassword = true;
                    user.TemporaryPassword = temp;

                    try
                    {
                        
                        if (!ModelState.Process(_userService.SaveOrUpdate(user)))
                            return View();                        

                        var loginUrl = Url.AbsoluteAction("Login", "Account");

                        new Mailer().ForgotPassword(new ForgotPasswordResetModel()
                        {
                            EmailAddress = user.Email,
                            FirstName = user.FirstName,
                            TemporaryPassword = temp,
                            UserName = user.Username,
                            LoginUrl = loginUrl
                        }).Send();

                        // send email
                        TempData.AddSuccessMessage("An email was sent to your account with password reset instructions");
                    }
                    catch (Exception ex)
                    {
                        TempData["Error"] = ex.Message;
                    }

                }

                // set flag to forgot password
            }
            return View(model);
        }
    }
}