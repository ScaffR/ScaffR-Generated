#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Data.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    public partial class Userchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Address", c => c.String());
            AddColumn("dbo.People", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PhoneNumber");
            DropColumn("dbo.People", "Address");
        }
    }
}
