namespace DemoApplication.Controllers.Users
{
    #region

    using System.Web.Mvc;
    using Security.Authorization;

    #endregion

    public partial class UsersController
    {
        [ClaimsAuthorize("View", "ManageUsers")]
        public ActionResult Manager(int page = 1, int pageSize = 10)
        {
            var model = UserService.Page(page, pageSize);
            return View(model);
        }
    }
}
