namespace Band.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaintenanceHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaintenanceHistories",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Comment = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Instruments", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaintenanceHistories", "ID", "dbo.Instruments");
            DropIndex("dbo.MaintenanceHistories", new[] { "ID" });
            DropTable("dbo.MaintenanceHistories");
        }
    }
}
