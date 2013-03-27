#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-19-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Membership
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Core.Model;
    using Data;

    #endregion

    public partial class MembershipDataSeeder
    {
        public void Seed(DataContext context)
        {
            new List<Role>()
                {
                    new Role()
                        {
                            RoleId = 1,
                            RoleName = "Super Admin"
                        }
                }.ForEach(a => context.Roles.AddOrUpdate(a));

            new List<User>()
                {
                    new User()
                        {
                            ID = 1,
                            Email = "webmaster@scaffr.com",
                            Username = "admin",
                            FirstName = "Rod",
                            LastName = "Johnson",
                            LastLogin = DateTime.UtcNow,
                            Gender = Gender.Male,
                            Address = "Admin address",
                            PhoneNumber = "555-555-5555",
                            IsLoginAllowed = true,
                            IsAccountClosed = false,
                            IsAccountVerified = true,
                            Created = DateTime.UtcNow,
                            Tenant = "default",
                            HashedPassword = "FA00.ACHEhktjwC+lLMLKq0PZXYsnr9HreWXtgMY55xMDY4ctWYeyzGPxt2vGLEtOEX2SKA==",
                            PasswordChanged = DateTime.UtcNow,
                            FailedLoginCount = 0
                        }
                }.ForEach(u => context.Users.AddOrUpdate(u));

            /*
            var existsInRole = context.UserClaims.Any(ur => ur.UserId == 1 && ur.UserId == 1);
                               
            if (!existsInRole)
            {
                new List<UserClaim>()
                {
                    new UserClaim()
                        {
                            Type = "1",
                            UserId = 1
                        }
                }.ForEach(ur => context.UserClaims.Add(ur));
            }
            */
        }
    }
}