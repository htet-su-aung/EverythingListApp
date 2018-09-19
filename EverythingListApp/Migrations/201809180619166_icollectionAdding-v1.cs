namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icollectionAddingv1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ListDetails", "ItemID");
            AddForeignKey("dbo.ListDetails", "ItemID", "dbo.Items", "ItemID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListDetails", "ItemID", "dbo.Items");
            DropIndex("dbo.ListDetails", new[] { "ItemID" });
        }
    }
}
