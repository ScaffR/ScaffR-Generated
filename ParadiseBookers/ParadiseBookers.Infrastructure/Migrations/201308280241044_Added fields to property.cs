namespace ParadiseBookers.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedfieldstoproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Description", c => c.String());
            AddColumn("dbo.Properties", "Owner_Id", c => c.Int());
            AddForeignKey("dbo.Properties", "Owner_Id", "dbo.Users", "Id");
            CreateIndex("dbo.Properties", "Owner_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Properties", new[] { "Owner_Id" });
            DropForeignKey("dbo.Properties", "Owner_Id", "dbo.Users");
            DropColumn("dbo.Properties", "Owner_Id");
            DropColumn("dbo.Properties", "Description");
        }
    }
}
