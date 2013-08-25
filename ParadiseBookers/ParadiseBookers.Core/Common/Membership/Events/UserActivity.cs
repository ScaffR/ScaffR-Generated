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

    public abstract class UserActivity
    {
        public readonly string FriendlyName;
        public User User { get; set; }

        protected UserActivity(User user, string friendlyName)
        {
            FriendlyName = friendlyName;
            User = user;
        }
    }
}
