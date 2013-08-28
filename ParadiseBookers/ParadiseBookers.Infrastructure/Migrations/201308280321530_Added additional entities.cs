namespace ParadiseBookers.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedadditionalentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.Geography(),
                        Name = c.String(),
                        Surfing = c.Boolean(nullable: false),
                        Description = c.String(),
                        SandType = c.String(),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.Geography(),
                        Category = c.String(),
                        Hours = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.Geography(),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.Int(nullable: false),
                        Price = c.String(),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LandingPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LandingPages");
            DropTable("dbo.Attractions");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Beaches");
        }
    }
}
