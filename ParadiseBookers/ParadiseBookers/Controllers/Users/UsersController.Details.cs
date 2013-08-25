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

using System.Web.Mvc;
using Omu.ValueInjecter;
using ParadiseBookers.Extensions.ModelStateHelpers;
using ParadiseBookers.Extensions.TempDataHelpers;
using ParadiseBookers.Models.Users;

namespace ParadiseBookers.Controllers.Users
{
    #region

    

    #endregion

    public partial class UsersController
    {
        /// <summary>
        /// Detailses the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var user = UserService.GetByID(id);

            var model = new UserViewModel();
            model.InjectFrom<UnflatLoopValueInjection>(user);
            model.Username = user.Username;

            return View(model);
        }

        /// <summary>
        /// Detailses the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Details(int id, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserService.GetByID(id);

                model.Username = user.Username;
                user.InjectFrom<UnflatLoopValueInjection>(model);
                
                if (ModelState.Process(UserService.SaveOrUpdate(user)))
                {
                    TempData.AddSuccessMessage("User was successfully updated");
                    return RedirectToAction("Manager", "Users");
                }                
            }
            return View(model);
        }
    }
}
