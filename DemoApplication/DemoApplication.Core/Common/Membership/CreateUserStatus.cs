namespace DemoApplication.Core.Common.Membership
{
    #region

    using System.ComponentModel;

    #endregion

    public enum CreateUserStatus
    {
        [Description("User was successfully created")]
        Success,

        [Description("Username is already in use")]
        DuplicateUserName,

        [Description("Email is already in use")]
        DuplicateEmail,
    }
}