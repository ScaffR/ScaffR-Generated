namespace DemoApplication.Core.Common.Membership.Events
{
    #region

    using Model;

    #endregion

    public class UserLoggedIn : UserActivity
    {
        public UserLoggedIn(User user) : base(user, "User Logged In")
        {           
        }
    }
}

