namespace DemoApplication.Core.Common.Membership
{
    #region

    using System.ComponentModel;

    #endregion

    public enum AuthenticationStatus
    {
        [Description("User is authenticated")]
        Authenticated,

        [Description("Invalid username or password")]
        InvalidUsername,

        [Description("Invalid username or password")]
        InvalidPassword,

        [Description("Please reset password")]
        ResetPassword,

        [Description("Your account has been locked out")]
        UserLockedOut,

        [Description("Your account is no longer active")]
        AccountNotActive
    }


}