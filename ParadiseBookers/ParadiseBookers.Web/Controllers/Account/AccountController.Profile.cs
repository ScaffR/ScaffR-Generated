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

using System;
using System.Web.Mvc;
using Omu.ValueInjecter;
using ParadiseBookers.Extensions.ModelStateHelpers;
using ParadiseBookers.Extensions.TempDataHelpers;
using ParadiseBookers.Infrastructure.Profiles;
using ParadiseBookers.Models.Account;

namespace ParadiseBookers.Controllers.Account
{
    #region

    

    #endregion

    /// <summary>
    /// Class AccountController
    /// </summary>
    public partial class AccountController
    {
        /// <summary>
        /// Profiles this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public new ActionResult Profile()
        {
            var model = new ProfileModel();

            model.InjectFrom<UnflatLoopValueInjection>(UserProfile.Current);

            return View(model);
        }

        /// <summary>
        /// Profiles the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public new ActionResult Profile(ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                UserProfile.Current.InjectFrom<UnflatLoopValueInjection>(model);

                try
                {
                    var result = _userService.SaveOrUpdate(UserProfile.Current);

                    if (ModelState.Process(result))
                    {
                        TempData.AddSuccessMessage("User was successfully updated.");
                        return RedirectToAction("Profile");
                    }                    
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Exception", "Unexpected error");
                }                
            }

            return View(model);
        }
    }
}
