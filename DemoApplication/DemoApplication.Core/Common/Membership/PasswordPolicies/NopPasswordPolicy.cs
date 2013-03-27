#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-25-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Core.Common.Membership.PasswordPolicies
{
    #region

    using Interfaces.Membership;

    #endregion

    public class NopPasswordPolicy : IPasswordPolicy
    {
        public string PolicyMessage
        {
            get { return "There is no password policy."; }
        }

        public bool ValidatePassword(string password)
        {
            return true;
        }
    }
}
