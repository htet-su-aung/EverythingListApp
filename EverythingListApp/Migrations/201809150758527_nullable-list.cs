namespace EverythingListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablelist : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lists", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Lists", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lists", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lists", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
