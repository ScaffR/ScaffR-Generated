namespace DemoApplication.Core.Common.Membership
{
    using System.ComponentModel;

    public enum ChangePasswordStatus
    {
        [Description("Password was successfully changed")]
        Success,

        [Description("Unable to change password")]
        Failure,

        [Description("Invalid password")]
        InvalidPassword
    }
}