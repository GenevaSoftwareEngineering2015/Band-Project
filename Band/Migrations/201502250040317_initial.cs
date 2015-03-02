namespace Band.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Instruments", newName: "CheckOuts");
            DropColumn("dbo.CheckOuts", "MaintenanceNeeded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckOuts", "MaintenanceNeeded", c => c.String());
            RenameTable(name: "dbo.CheckOuts", newName: "Instruments");
        }
    }
}
