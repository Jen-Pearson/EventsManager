namespace EventsManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovedUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValidEmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApprovedUsers");
        }
    }
}
