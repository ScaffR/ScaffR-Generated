namespace DemoApplication.Core.Common.Membership.Events
{
    using Model;

    public class UserLockedOut
    {
        public readonly User User;

        public UserLockedOut(User user)
        {
            User = user;
        }
    }
}
