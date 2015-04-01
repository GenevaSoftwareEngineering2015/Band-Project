namespace Band.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class COIFK2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruments", "ID", "dbo.CheckOuts");
            DropIndex("dbo.Instruments", new[] { "ID" });
            RenameColumn(table: "dbo.CheckOuts", name: "ID", newName: "InstID");
            DropPrimaryKey("dbo.CheckOuts");
            DropPrimaryKey("dbo.Instruments");
            DropColumn("dbo.Instruments", "ID");
            AddColumn("dbo.Instruments", "InstID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CheckOuts", "InstID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CheckOuts", new[] { "Date", "InstID" });
            AddPrimaryKey("dbo.Instruments", "InstID");
            CreateIndex("dbo.CheckOuts", "InstID");
            AddForeignKey("dbo.CheckOuts", "InstID", "dbo.Instruments", "InstID");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instruments", "ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CheckOuts", "InstID", "dbo.Instruments");
            DropIndex("dbo.CheckOuts", new[] { "InstID" });
            DropPrimaryKey("dbo.Instruments");
            DropPrimaryKey("dbo.CheckOuts");
            AlterColumn("dbo.CheckOuts", "InstID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Instruments", "InstID");
            AddPrimaryKey("dbo.Instruments", "ID");
            AddPrimaryKey("dbo.CheckOuts", "ID");
            RenameColumn(table: "dbo.CheckOuts", name: "InstID", newName: "ID");
            CreateIndex("dbo.Instruments", "ID");
            AddForeignKey("dbo.Instruments", "ID", "dbo.CheckOuts", "ID");
        }
    }
}
