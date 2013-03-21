#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Membership
{
    #region

    using System.Data.Entity;
    using Core.Model;
    using Data;

    #endregion

    public class MembershipContext : BaseContext<MembershipContext>
    {
        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
