#region credits
// ***********************************************************************
// Assembly	: DemoApplication
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Controllers.Users
{
    #region

    using System.Web.Mvc;
    using Core.Interfaces.Service;

    #endregion

    /// <summary>
    /// Class UsersController
    /// </summary>
    public partial class UsersController : Controller
    {
        protected readonly IUserService UserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

    }
}
