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