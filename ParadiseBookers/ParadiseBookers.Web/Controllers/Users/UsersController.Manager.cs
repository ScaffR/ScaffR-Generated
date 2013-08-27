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

using System.Linq;
using System.Web.Mvc;

namespace ParadiseBookers.Controllers.Users
{
    #region

    

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
