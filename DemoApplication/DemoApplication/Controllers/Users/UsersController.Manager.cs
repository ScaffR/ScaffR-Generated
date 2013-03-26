#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Users
{
    #region

    using System.Linq;
    using System.Web.Mvc;

    #endregion

    public partial class UsersController
    {        
        public ActionResult Manager(int page = 1, int pageSize = 10)
        {
            var model = UserService.GetAll("default").ToList();
            return View(model);
        }
    }
}
