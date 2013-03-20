namespace DemoApplication.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Thread = c.String(maxLength: 255),
                        Level = c.String(maxLength: 50),
                        Logger = c.String(maxLength: 255),
                        Message = c.String(maxLength: 4000),
                        Exception = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.LogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Log");
        }
    }
}
