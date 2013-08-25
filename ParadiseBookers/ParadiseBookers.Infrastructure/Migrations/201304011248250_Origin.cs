using System.Data.Entity.Migrations;

namespace ParadiseBookers.Infrastructure.Migrations
{
    public partial class Origin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Type = c.String(nullable: false, maxLength: 150),
                        Value = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => new { t.UserId, t.Type, t.Value })
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Thread = c.String(maxLength: 255),
                        Level = c.String(maxLength: 50),
                        Logger = c.String(maxLength: 255),
                        Message = c.String(maxLength: 4000),
                        Exception = c.String(maxLength: 2000),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropTable("dbo.Logs");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
        }
    }
}
