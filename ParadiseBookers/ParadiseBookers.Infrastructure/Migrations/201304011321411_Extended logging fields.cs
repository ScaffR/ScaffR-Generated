using System.Data.Entity.Migrations;

namespace ParadiseBookers.Infrastructure.Migrations
{
    public partial class Extendedloggingfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "MachineName", c => c.String());
            AddColumn("dbo.Logs", "Details", c => c.String());
            AddColumn("dbo.Logs", "EventType", c => c.String());
            AddColumn("dbo.Logs", "EventSequence", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Logs", "EventOccurrence", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Logs", "RequestUrl", c => c.String());
            AddColumn("dbo.Logs", "EventCode", c => c.Int(nullable: false));
            AddColumn("dbo.Logs", "ExceptionType", c => c.String());
            AddColumn("dbo.Logs", "EventDetailCode", c => c.Int(nullable: false));
            AddColumn("dbo.Logs", "ApplicationPath", c => c.String());
            AddColumn("dbo.Logs", "ApplicationVirtualPath", c => c.String());
            AddColumn("dbo.Logs", "Tenant", c => c.String());
            AddColumn("dbo.Logs", "Username", c => c.String());
            AlterColumn("dbo.Logs", "Message", c => c.String());
            DropColumn("dbo.Logs", "Thread");
            DropColumn("dbo.Logs", "Level");
            DropColumn("dbo.Logs", "Logger");
            DropColumn("dbo.Logs", "Exception");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "Exception", c => c.String(maxLength: 2000));
            AddColumn("dbo.Logs", "Logger", c => c.String(maxLength: 255));
            AddColumn("dbo.Logs", "Level", c => c.String(maxLength: 50));
            AddColumn("dbo.Logs", "Thread", c => c.String(maxLength: 255));
            AlterColumn("dbo.Logs", "Message", c => c.String(maxLength: 4000));
            DropColumn("dbo.Logs", "Username");
            DropColumn("dbo.Logs", "Tenant");
            DropColumn("dbo.Logs", "ApplicationVirtualPath");
            DropColumn("dbo.Logs", "ApplicationPath");
            DropColumn("dbo.Logs", "EventDetailCode");
            DropColumn("dbo.Logs", "ExceptionType");
            DropColumn("dbo.Logs", "EventCode");
            DropColumn("dbo.Logs", "RequestUrl");
            DropColumn("dbo.Logs", "EventOccurrence");
            DropColumn("dbo.Logs", "EventSequence");
            DropColumn("dbo.Logs", "EventType");
            DropColumn("dbo.Logs", "Details");
            DropColumn("dbo.Logs", "MachineName");
        }
    }
}
