#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 02-24-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion

using DemoApplication.Core.Model;

namespace DemoApplication.Core.Interfaces.Service
{
    public interface IAuthenticationService
    {
        void SignIn(User user);
        void SignOut();
    }
}
