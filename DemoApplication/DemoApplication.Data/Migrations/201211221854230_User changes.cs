namespace DemoApplication.Data.Migrations
{
    using System.Data.Entity.Migrations;

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
