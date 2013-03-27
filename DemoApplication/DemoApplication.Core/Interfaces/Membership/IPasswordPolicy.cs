#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-23-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion

namespace DemoApplication.Core.Interfaces.Membership
{
    public interface IPasswordPolicy
    {
        string PolicyMessage { get; }
        bool ValidatePassword(string password);
    }
}
