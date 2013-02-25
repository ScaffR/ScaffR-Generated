namespace DemoApplication.Controllers.Users
{
    using System.Web.Mvc;
    using IdentityModel.Authorization.MVC;
    using Models.Users;
    using Omu.ValueInjecter;

    public partial class UsersController
    {
        [HttpGet]
        [ClaimsAuthorize("View", "ManageUsers")]
        public ActionResult Details(int id)
        {
            var user = UserService.GetById(id);

            var model = new UserViewModel();
            model.InjectFrom<UnflatLoopValueInjection>(user);
            model.Username = user.Username;

            return View(model);
        }

        [HttpPost]
        [ClaimsAuthorize("View", "ManageUsers")]
        public ActionResult Details(int id, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserService.GetById(id);

                model.Username = user.Username;
                user.InjectFrom<UnflatLoopValueInjection>(model);
                
                var result = UserService.SaveOrUpdate(user);
                
                foreach(var r in result.ValidationErrors)
                {
                    foreach (var e in r.Value)
                    {
                        ModelState.AddModelError(r.Key, e);
                    }
                }

                if (ModelState.IsValid)
                {
                    TempData["Success"] = "User was successfully updated";

                    return RedirectToAction("Manager", "Users");
                }
            }
            return View(model);
        }
    }
}
