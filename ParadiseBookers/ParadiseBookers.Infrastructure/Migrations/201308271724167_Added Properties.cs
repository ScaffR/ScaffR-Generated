namespace ParadiseBookers.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.Geography(),
                        BedRooms = c.Int(nullable: false),
                        BathRooms = c.Int(nullable: false),
                        Sleeps = c.Int(nullable: false),
                        PetsAllowed = c.Boolean(nullable: false),
                        CableTv = c.Boolean(nullable: false),
                        DvdPlayer = c.Boolean(nullable: false),
                        Pool = c.Int(nullable: false),
                        FloorArea = c.Int(nullable: false),
                        FullKitchen = c.Boolean(nullable: false),
                        Refrigerator = c.Boolean(nullable: false),
                        CoffeeMaker = c.Boolean(nullable: false),
                        Microwave = c.Boolean(nullable: false),
                        Cookware = c.Boolean(nullable: false),
                        Dishwasher = c.Boolean(nullable: false),
                        Oven = c.Boolean(nullable: false),
                        CentralAir = c.Boolean(nullable: false),
                        CeilingFans = c.Boolean(nullable: false),
                        Linens = c.Boolean(nullable: false),
                        WasherAndDryer = c.Boolean(nullable: false),
                        Wifi = c.Boolean(nullable: false),
                        TwentyFourSecurity = c.Boolean(nullable: false),
                        Elevator = c.Boolean(nullable: false),
                        Towels = c.Boolean(nullable: false),
                        Phone = c.Boolean(nullable: false),
                        Furninishing = c.Int(nullable: false),
                        BeachNearby = c.Boolean(nullable: false),
                        BeachDistanceMiles = c.Int(nullable: false),
                        Created = c.DateTime(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Properties");
        }
    }
}
