namespace DemoApplication.Core.Common.Membership.Events
{
    using Model;

    public class UserLoggedOut : UserActivity
    {
        public UserLoggedOut(User user) : base(user, "User Logged Out")
        {
        }
    }
}
