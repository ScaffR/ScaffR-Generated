namespace DemoApplication.Core.Common.Membership.Events
{
    using Model;

    public class UserLoggedIn : UserActivity
    {
        public UserLoggedIn(User user) : base(user, "User Logged In")
        {           
        }
    }
}

