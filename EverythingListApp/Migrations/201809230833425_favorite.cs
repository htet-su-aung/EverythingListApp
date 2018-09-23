namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        ListID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserID, t.ListID })
                .ForeignKey("dbo.Lists", t => t.ListID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ListID)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Favorites", "ListID", "dbo.Lists");
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            DropIndex("dbo.Favorites", new[] { "ListID" });
            DropTable("dbo.Favorites");
        }
    }
}
