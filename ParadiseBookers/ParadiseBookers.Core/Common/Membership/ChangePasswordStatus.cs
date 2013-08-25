#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.ComponentModel;

namespace ParadiseBookers.Core.Common.Membership
{
    #region

    

    #endregion

    public enum ChangePasswordStatus
    {
        [Description("Password was changed successfully")]
        Success,

        [Description("It was not possible change your password, please try again.")]
        Failure,

        [Description("The current password is incorrect or the new password is invalid.")]
        InvalidPassword
    }
}