namespace DemoApplication.Controllers.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Core.Model;
    using Extensions;
    using Models;
    using Models.Account;
    using Omu.ValueInjecter;

    public partial class AccountController
    {
        [HttpGet]
        public new ActionResult Profile()
        {
            var model = new ProfileModel();

            model.InjectFrom<UnflatLoopValueInjection>(this.GetCurrentUser());

            return View(model);
        }

        [HttpPost]
        public new ActionResult Profile(ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.Compare(this.GetCurrentUser().Email, model.Email, StringComparison.InvariantCultureIgnoreCase) != 0)
                {
                    var inUse = _userService.Find(u => u.Email == model.Email).Any();
                    if (inUse)
                    {
                        ModelState.AddModelError("EmailInUse", "Email already in use");
                    }
                }

                this.GetCurrentUser().InjectFrom<UnflatLoopValueInjection>(model);

                try
                {
					_userService.SaveOrUpdate(this.GetCurrentUser());
                    TempData["Success"] = "User was successfully updated.";
                    return RedirectToAction("Profile");
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
