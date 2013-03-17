namespace DemoApplication.Core.Common.Profiles
{
    #region

    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using Interfaces.Service;
    using Interfaces.Validation;
    using Model;

    #endregion

    public class UserProfile
    {
        public static User Current
        {
            get
            {                
                var user = HttpContext.Current.Session["UserProfile"] as User;
                if (user == null)
                {
                    HttpContext.Current.Session["UserProfile"] = user =
                            DependencyResolver.Current.GetService<IUserService>()
                                              .GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                }
                return user;
            }
        }
    }

    public static class UserExtensions
    {
        public static IValidationContainer<User> Save(this User user)
        {
            var service = DependencyResolver.Current.GetService<IUserService>();
            return service.SaveOrUpdate(user);
        }
    }
}