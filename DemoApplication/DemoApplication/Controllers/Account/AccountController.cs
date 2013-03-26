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
namespace DemoApplication.Controllers.Account
{
    #region

    using System.Web.Mvc;
    using Core.Interfaces.Eventing;
    using Core.Interfaces.Membership;
    using Core.Interfaces.Service;
    using Core.Services;
    using Filters;

    #endregion

    [ShowBreadcrumb(false)]
    public partial class AccountController : Controller
    {
        private readonly IUserAccountService _userService;

        private readonly IAuthenticationService _authenticationService;
        private readonly IMessageBus _messageBus;
        private readonly IMembershipSettings _membershipSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="authenticationService">The authentication service.</param>
        /// <param name="messageBus">The message bus.</param>
        /// <param name="membershipSettings"></param>
        public AccountController(IUserAccountService userService, IAuthenticationService authenticationService, IMessageBus messageBus, IMembershipSettings membershipSettings)
        {
            _membershipSettings = membershipSettings;
            _messageBus = messageBus;
            _userService = userService;
            _authenticationService = authenticationService;
        }       
    }
}