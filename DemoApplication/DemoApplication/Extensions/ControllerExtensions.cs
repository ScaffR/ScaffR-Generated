namespace DemoApplication.Extensions
{
    using System.Security.Claims;
    using System.Web.Mvc;
    using Core.Interfaces.Service;
    using Core.Model;

    public static partial class ControllerExtensions
    {
        private static User _currentUser;
        public static User GetCurrentUser(this ControllerBase controller)
        {
            if (_currentUser != null)
            {
                return _currentUser;
            }

            var userService = DependencyResolver.Current.GetService<IUserService>();

            _currentUser = userService.GetByUsername(ClaimsPrincipal.Current.Identity.Name);
            if (_currentUser == null && !string.IsNullOrEmpty(ClaimsPrincipal.Current.Identity.Name))
            {
                var authenticationService = DependencyResolver.Current.GetService<IAuthenticationService>();
                authenticationService.SignOut();
            }

            return _currentUser;
        }

        public static User GetCurrentUser(this Controller controller)
        {
            return ((ControllerBase)controller).GetCurrentUser();
        }
    }
}