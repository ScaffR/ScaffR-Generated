namespace DemoApplication.Core.Common.Membership.Events
{
    using Model;

    public class UserCreated : UserActivity
    {
        public readonly string LoginUrl;

        public UserCreated(User user, string loginUrl) : base(user, "User Created")
        {
            LoginUrl = loginUrl;
        }
    }
}