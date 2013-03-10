namespace DemoApplication.Core.Common.Profiles
{
    using System.Threading;
    using System.Web.Mvc;
    using Infrastructure.Interfaces.Storage;
    using Interfaces.Service;
    using Interfaces.Validation;
    using Model;

    public class UserProfile
    {
        private static readonly IStorageProvider Storage;
        static UserProfile()
        {
            Storage = DependencyResolver.Current.GetService<IStorageProvider>();
        }

        public static User Current
        {
            get { 
                var user = Storage.GetValue<User>("UserProfile") as User;
                if (user == null)
                {
                    Storage.SetValue("UserProfile",
                        user =
                            DependencyResolver.Current.GetService<IUserService>()
                                              .GetByUsername(Thread.CurrentPrincipal.Identity.Name));
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
