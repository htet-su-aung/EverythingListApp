namespace EverythingListApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EverythingListApp.DAL;
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
            var dbInit = new DbInitializer();
            dbInit.SeedCategory(context);
            dbInit.SeedItem(context);
            dbInit.SeedList(context);
            dbInit.SeedListDetail(context);
        }
    }
}
