#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-18-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-18-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        Comment = c.String(),
                        ResetPassword = c.Boolean(nullable: false),
                        ShowWelcomePage = c.Boolean(nullable: false),
                        TemporaryPassword = c.String(),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        PhotoId = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        LastPasswordFailureDate = c.DateTime(),
                        LastActivityDate = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        IsLockedOut = c.Boolean(nullable: false),
                        LastPasswordChangedDate = c.DateTime(),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);

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
