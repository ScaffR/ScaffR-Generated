#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-27-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-28-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    public partial class Removeduserclaimsfromdatacontext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserClaims", "Type", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.UserClaims", "Value", c => c.String(nullable: false, maxLength: 150));
            DropPrimaryKey("dbo.UserClaims", new[] { "Id" });
            AddPrimaryKey("dbo.UserClaims", new[] { "UserId", "Type", "Value" });
            DropColumn("dbo.UserClaims", "Id");
            DropColumn("dbo.UserClaims", "Created");
            DropColumn("dbo.UserClaims", "Updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserClaims", "Updated", c => c.DateTime());
            AddColumn("dbo.UserClaims", "Created", c => c.DateTime());
            AddColumn("dbo.UserClaims", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.UserClaims", new[] { "UserId", "Type", "Value" });
            AddPrimaryKey("dbo.UserClaims", "Id");
            AlterColumn("dbo.UserClaims", "Value", c => c.String(maxLength: 150));
            AlterColumn("dbo.UserClaims", "Type", c => c.String(maxLength: 150));
        }
    }
}
