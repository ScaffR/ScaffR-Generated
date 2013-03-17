#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Core
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Core.Services
{
    #region

    using System;
    using System.Linq;
    using Model;

    #endregion

    public partial class UserService
    {
        public User GetByUsername(string userName)
        {
            return Find(u => u.Username.Equals(userName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
    }
}