namespace DemoApplication.Controllers.Account
{
    using System.Web.Mvc;
    using Core.Interfaces.Service;
    using Filters;

    [ShowBreadcrumb(false)]
    public partial class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserEmailService _userEmailService;

        private readonly IAuthenticationService _authenticationService;
        
        public AccountController(IUserService userService, IUserEmailService userEmailService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _userEmailService = userEmailService;
            _authenticationService = authenticationService;
        }       
    }
}