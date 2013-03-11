namespace DemoApplication.Data.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DemoApplication.Core.Model;

    public partial class MembershipDataSeeder
    {
        public void Seed(DataContext context)
        {
            new List<Role>()
                {
                    new Role()
                        {
                            Id = 1,
                            RoleName = "Super Admin"
                        }
                }.ForEach(a => context.Roles.AddOrUpdate(a));

            new List<User>()
                {
                    new User()
                        {
                            Id = 1,
                            Email = "webmaster@scaffr.com",
                            Username = "admin",
                            FirstName = "Rod",
                            LastName = "Johnson",
                            LastLoginDate = DateTime.Now,
                            Password = "admin",
                            IsApproved = true,							
                            Gender = Gender.Male,
                            Address = "Admin address",
                            PhoneNumber = "555-555-5555"
                        }
                }.ForEach(u => context.Users.AddOrUpdate(u));

            var existsInRole = context.UserRoles.Any(ur => ur.UserId == 1 && ur.UserId == 1);
                               
            if (!existsInRole)
            {
                new List<UserRole>()
                {
                    new UserRole()
                        {
                            RoleId = 1,
                            UserId = 1
                        }
                }.ForEach(ur => context.UserRoles.Add(ur));
            }

        }
    }
}