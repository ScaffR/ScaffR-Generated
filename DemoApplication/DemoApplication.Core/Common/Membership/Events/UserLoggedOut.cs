#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-19-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Common.Membership.Events
{
    #region

    using Model;

    #endregion

    public class UserLoggedOut : UserActivity
    {
        public UserLoggedOut(User user) : base(user, "User Logged Out")
        {
        }
    }
}
