namespace DemoApplication.Core.Common.Membership.Events
{
    using Model;

    public abstract class UserActivity
    {
        public readonly string FriendlyName;
        public User User { get; set; }

        protected UserActivity(User user, string friendlyName)
        {
            FriendlyName = friendlyName;
            User = user;
        }
    }
}
