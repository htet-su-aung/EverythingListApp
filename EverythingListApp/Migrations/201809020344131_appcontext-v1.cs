namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appcontextv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                        ListDescription = c.String(),
                        PplQty = c.Int(nullable: false),
                        Location = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ListID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.ListDetails",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        ListID = c.Int(nullable: false),
                        ItemQty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.ListID })
                .ForeignKey("dbo.Lists", t => t.ListID, cascadeDelete: true)
                .Index(t => t.ListID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        ShopLink = c.String(),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListDetails", "ListID", "dbo.Lists");
            DropForeignKey("dbo.Lists", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.ListDetails", new[] { "ListID" });
            DropIndex("dbo.Lists", new[] { "Category_CategoryID" });
            DropTable("dbo.Items");
            DropTable("dbo.ListDetails");
            DropTable("dbo.Lists");
            DropTable("dbo.Categories");
        }
    }
}
