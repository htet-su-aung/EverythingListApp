namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduseridtolistv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "UserID_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Lists", "UserID_Id");
            AddForeignKey("dbo.Lists", "UserID_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lists", "UserID_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Lists", new[] { "UserID_Id" });
            DropColumn("dbo.Lists", "UserID_Id");
        }
    }
}
