#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-18-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion

using System.Data.Entity.Migrations;
using ParadiseBookers.Infrastructure.Data;
using ParadiseBookers.Infrastructure.Membership;

namespace ParadiseBookers.Infrastructure.Migrations
{
    #region

    

    #endregion

    #region

    

    #endregion

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            new MembershipDataSeeder().Seed(context);
        }
    }
}
