namespace DemoApplication.Core.Interfaces.Service
{
    using Common.Membership;
    using Model;

    public partial interface IUserService
    {
        AuthenticationStatus Authenticate(string username, string password, out User user);
        ChangePasswordStatus ChangePassword(User user, string currentPassword, string newPassword);
        CreateUserStatus CreateUser(User user);
        ChangePasswordStatus ResetPassword(User user);
        bool UserExistsAlready(string userName);
    }
}