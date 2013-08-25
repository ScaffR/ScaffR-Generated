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
using ParadiseBookers.Core.Interfaces.Service;
using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Controllers.Users
{
    #region

    

    #endregion

    /// <summary>
    /// Class UsersController
    /// </summary>
    [Authorize(Roles = "Admin,Super Admin")]
    public partial class UsersController : Controller
    {
        protected readonly IUserAccountService UserService;
        private readonly IService<Log> _logging;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UsersController(IUserAccountService userService, IService<Log> logging)
        {
            UserService = userService;
            _logging = logging;
        }
    }
}
