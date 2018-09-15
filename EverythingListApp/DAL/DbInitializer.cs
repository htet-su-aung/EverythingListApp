using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EverythingListApp.Models;

namespace EverythingListApp.DAL
{
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        public DbInitializer()
        {

        }
        //public void Seed(ApplicationDbContext context)
        //{
        //    var items = new List<Item>
        //    {
        //    new Item{ItemID=1,ItemName="sunglasses",ItemDescription="to protect UV rays",ShopLink="www.amazon.com"},
        
        //    };
        //    items.ForEach(s => context.Items.Add(s));
        //    context.SaveChanges();
        //    //base.Seed(context);
        //}
    }
}