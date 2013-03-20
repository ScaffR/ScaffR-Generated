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
namespace DemoApplication.Core.Interfaces.Service
{
    #region

    using Model;

    #endregion

    public interface IAuthenticationService
    {
        void SignIn(User user);
        void SignOut();
    }
}
