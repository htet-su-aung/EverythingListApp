namespace EverythingListApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EverythingListApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EverythingListApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EverythingListApp.Models.ApplicationDbContext";
          
    

    }

    protected override void Seed(EverythingListApp.Models.ApplicationDbContext context)
        {
            //var items = new List<Item>
            //{
            //new Item{ItemID=1,ItemName="sunglasses",ItemDescription="to protect UV rays",ShopLink="www.amazon.com"},

            //    };
            //items.ForEach(s => context.Items.Add(s));
            //context.SaveChanges();
            //base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
