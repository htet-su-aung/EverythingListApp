namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFullNameuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
