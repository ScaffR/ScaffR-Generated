

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
        public ActionResult Emails()
        {
            var user = this.GetCurrentUser();

            List<UserEmail> model = _userEmailService.Find(x => x.UserId == user.Id).ToList();

            ViewBag.DefaultEmail = this.GetCurrentUser().Email;

            return View(model);
        }

        [HttpPost]
        public ActionResult Emails(UserEmail model)
        {
            model.UserId = this.GetCurrentUser().Id;
            if (ModelState.IsValid)
            {
                _userEmailService.SaveOrUpdate(model);
                TempData["Success"] = "Email was successfully added";
            }

            return RedirectToAction("Emails");
        }    
    }
}