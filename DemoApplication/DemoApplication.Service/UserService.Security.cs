namespace DemoApplication.Service
{
    using System.Linq;
    using System;
    using DemoApplication.Core.Model;

    public partial class UserService
    {
        public User GetByUsername(string userName)
        {
            return Find(u => u.Username.Equals(userName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
    }
}