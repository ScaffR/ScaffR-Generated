#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Account
{
    #region

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Security.Authorization;
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
                try
                {
                    var user = _userService.CreateAccount(model.Username, model.Password, model.Email,model.FirstName, model.LastName, model.PhoneNumber, model.Address);
                    if (ModelState.Process(user))
                    {
                        if (_membershipSettings.RequireAccountVerification)
                        {
                            return View("RegisterSuccess", model);
                        }
                        return View("RegisterConfirm", true);
                    }                   
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        /// <summary>
        /// Confirms a new registration
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Confirm(string id)
        {
            var result = _userService.VerifyAccount(id);
            return View("RegisterConfirm", result.IsValid);
        }

        /// <summary>
        /// Cancels an existing registration
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous, OnlyAnonymous, ShowMainMenu(false)]
        public ActionResult Cancel(string id)
        {
            var result = _userService.CancelNewAccount(id);
            return View("RegisterCancel", result);
        }
    }
}