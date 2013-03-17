namespace DemoApplication.Core.Common.Membership.Events
{
    #region

    using Model;

    #endregion

    public class UserLockedOut
    {
        public readonly User User;

        public UserLockedOut(User user)
        {
            User = user;
        }
    }
}
