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

using ParadiseBookers.Core.Model;

namespace ParadiseBookers.Core.Common.Membership.Events
{
    #region

    

    #endregion

    public class UserLoggedOut : UserActivity
    {
        public UserLoggedOut(User user) : base(user, "User Logged Out")
        {
        }
    }
}
