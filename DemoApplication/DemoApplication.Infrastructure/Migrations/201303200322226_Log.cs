#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-20-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-21-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

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
