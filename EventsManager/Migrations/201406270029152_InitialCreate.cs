namespace EventsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        EventDescription = c.String(),
                        EventDate = c.DateTime(nullable: false),
                        ThumbnailUrl = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalendarEvents");
        }
    }
}
