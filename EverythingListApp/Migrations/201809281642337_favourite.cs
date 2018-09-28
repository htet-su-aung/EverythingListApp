namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favourite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        ListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ListID })
                .ForeignKey("dbo.Lists", t => t.ListID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ListID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "ListID", "dbo.Lists");
            DropIndex("dbo.Favorites", new[] { "ListID" });
            DropIndex("dbo.Favorites", new[] { "UserID" });
            DropTable("dbo.Favorites");
        }
    }
}
