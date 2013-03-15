namespace DemoApplication.Core.Interfaces.Service
{
    using Common.Membership;
    using Model;

    public partial interface IUserService
    {
        bool Authenticate(string username, string password, out AuthenticationStatus status);
        ChangePasswordStatus ChangePassword(User user, string currentPassword, string newPassword);
        CreateUserStatus CreateUser(User user);
        ChangePasswordStatus ResetPassword(User user);
        bool UserExistsAlready(string userName);
    }
}