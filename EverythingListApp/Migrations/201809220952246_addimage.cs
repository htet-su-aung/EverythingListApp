namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lists", "Image");
        }
    }
}
