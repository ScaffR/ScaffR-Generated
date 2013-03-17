namespace DemoApplication.Core.Common.Membership.Events
{
    #region

    using Model;

    #endregion

    public class UserLoggedOut : UserActivity
    {
        public UserLoggedOut(User user) : base(user, "User Logged Out")
        {
        }
    }
}
