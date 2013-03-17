namespace DemoApplication.Core.Common.Membership
{
    #region

    using System.ComponentModel;

    #endregion

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