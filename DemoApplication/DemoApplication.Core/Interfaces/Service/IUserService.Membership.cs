namespace DemoApplication.Core.Interfaces.Service
{
    #region

    using Common.Membership;
    using Model;

    #endregion

    public partial interface IUserService
    {
        bool Authenticate(string username, string password, out AuthenticationStatus status, out User usr);
        ChangePasswordStatus ChangePassword(User user, string currentPassword, string newPassword);
        CreateUserStatus CreateUser(User user);
        ChangePasswordStatus ResetPassword(User user);
        bool UserExistsAlready(string userName);
    }
}