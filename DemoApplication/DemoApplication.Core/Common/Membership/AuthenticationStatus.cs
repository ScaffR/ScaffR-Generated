namespace DemoApplication.Core.Common.Membership
{
    public enum AuthenticationStatus
    {
        Authenticated,
        InvalidUsername,
        InvalidPassword,
        ResetPassword,
        UserLockedOut,
        AccountNotActive
    }
}