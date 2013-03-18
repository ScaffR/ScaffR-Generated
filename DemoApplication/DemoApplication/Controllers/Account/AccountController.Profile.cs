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

    using System;
    using System.Web.Mvc;
    using Core.Common.Profiles;
    using Extensions.ModelStateHelpers;
    using Extensions.TempDataHelpers;
    using Models.Account;
    using Omu.ValueInjecter;

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
                    var result = UserProfile.Current.Save();

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
