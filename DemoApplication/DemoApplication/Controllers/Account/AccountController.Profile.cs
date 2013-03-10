namespace DemoApplication.Controllers.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Core.Common.Profiles;
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

            model.InjectFrom<UnflatLoopValueInjection>(UserProfile.Current);

            return View(model);
        }

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
                        TempData["Success"] = "User was successfully updated.";
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

        [HttpGet]
        public ActionResult Emails()
        {
            var user = UserProfile.Current;

            List<UserEmail> model = _userEmailService.Find(x => x.UserId == user.Id).ToList();

            ViewBag.DefaultEmail = UserProfile.Current.Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult Emails(UserEmail model)
        {
            model.UserId = UserProfile.Current.Id;
            if (ModelState.IsValid)
            {
                var result = _userEmailService.SaveOrUpdate(model);
                if (ModelState.Process(result))
                {
                    TempData["Success"] = "Email was successfully added";
                    return RedirectToAction("Emails");
                }
                
            }

            return RedirectToAction("Emails");
        }       
    }
}
