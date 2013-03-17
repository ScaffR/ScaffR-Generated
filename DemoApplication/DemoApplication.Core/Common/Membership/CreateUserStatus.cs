namespace DemoApplication.Core.Common.Membership
{
    using System.ComponentModel;

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