namespace DemoApplication.Core.Common.Membership.Events
{
    #region

    using Model;

    #endregion

    public class UserCreated : UserActivity
    {
        public readonly string LoginUrl;

        public UserCreated(User user, string loginUrl) : base(user, "User Created")
        {
            LoginUrl = loginUrl;
        }
    }
}