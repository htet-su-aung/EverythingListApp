namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lists", "UserID");
            AddForeignKey("dbo.Lists", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lists", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Lists", new[] { "UserID" });
            DropColumn("dbo.Lists", "UserID");
        }
    }
}
