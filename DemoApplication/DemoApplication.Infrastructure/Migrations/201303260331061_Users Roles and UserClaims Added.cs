#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-25-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-26-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    public partial class UsersRolesandUserClaimsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 150),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UserId, t.Type, t.Value })
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhotoId = c.String(),
                        Tenant = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PasswordChanged = c.DateTime(nullable: false),
                        IsAccountVerified = c.Boolean(nullable: false),
                        IsLoginAllowed = c.Boolean(nullable: false),
                        IsAccountClosed = c.Boolean(nullable: false),
                        AccountClosed = c.DateTime(),
                        LastLogin = c.DateTime(),
                        LastFailedLogin = c.DateTime(),
                        FailedLoginCount = c.Int(nullable: false),
                        VerificationKey = c.String(maxLength: 100),
                        VerificationKeySent = c.DateTime(),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Comment = c.String(),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.UserClaims");
        }
    }
}
