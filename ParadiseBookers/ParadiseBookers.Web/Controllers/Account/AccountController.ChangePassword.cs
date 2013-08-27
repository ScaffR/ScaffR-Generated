#region credits
// ***********************************************************************
// Assembly	: ParadiseBookers
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ParadiseBookers.Models.Account;

namespace ParadiseBookers.Controllers.Account
{
    #region

    

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
                try
                {
                    if (this._userService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                    {
                        return View("ChangePasswordSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error changing password");
                    }
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
    }
}
