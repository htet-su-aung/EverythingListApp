using EverythingListApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EverythingListApp.DAL
{
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        public void SeedCategory(ApplicationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category{CategoryName="Trip"},
                new Category{CategoryName="Journey"},
                new Category{CategoryName="Picnic"}
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
        }

        public void SeedItem(ApplicationDbContext context)
        {
            var items = new List<Item>
            {
                new Item{ItemName="Item 1", ItemDescription="Desc ... Item 1", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 2", ItemDescription="Desc ... Item 2", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 3", ItemDescription="Desc ... Item 3", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 4", ItemDescription="Desc ... Item 4", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 5", ItemDescription="Desc ... Item 5", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 6", ItemDescription="Desc ... Item 6", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 7", ItemDescription="Desc ... Item 7", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 8", ItemDescription="Desc ... Item 8", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 9", ItemDescription="Desc ... Item 9", ShopLink="www.shop.com.mm"},
                new Item{ItemName="Item 10", ItemDescription="Desc ... Item 10", ShopLink="www.shop.com.mm"},
            };
            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();
        }

        public void SeedList(ApplicationDbContext context)
        {
            Category trip = context.Categories.Find(1);
            Category journey = context.Categories.Find(2);
            Category picnic = context.Categories.Find(3);

            var tbList = new List<List>
            {
                new List{ListName="List1",ListDescription="Testing List1...",PplQty=2, Location="Mandalay", StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(5),Duration=5,Category=trip},
                new List{ListName="List2",ListDescription="Testing List2...",PplQty=2, Location="Lasho", StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(7),Duration=7,Category=journey},
                new List{ListName="List3",ListDescription="Testing List3...",PplQty=2, Location="Sagaing", StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(6),Duration=6,Category=journey},
                new List{ListName="List4",ListDescription="Testing List4...",PplQty=2, Location="NayPyiTaw", StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(1),Duration=1,Category=picnic},
                new List{ListName="List5",ListDescription="Testing List5...",PplQty=2, Location="MawLaMyine", StartDate=DateTime.Now,EndDate=DateTime.Now.AddDays(3),Duration=3,Category=trip},
            };
            tbList.ForEach(s => context.TBLists.Add(s));
            context.SaveChanges();
        }

        public void SeedListDetail(ApplicationDbContext context)
        {
            List list1 = context.TBLists.Find(1);
            List List2 = context.TBLists.Find(2);
            List List3 = context.TBLists.Find(3);
            List List4 = context.TBLists.Find(4);
            List List5 = context.TBLists.Find(5);

            Item Item1 = context.Items.Find(1);
            Item Item2 = context.Items.Find(2);
            Item Item3 = context.Items.Find(3);
            Item Item4 = context.Items.Find(4);
            Item Item5 = context.Items.Find(5);
            Item Item6 = context.Items.Find(6);
            Item Item7 = context.Items.Find(7);
            Item Item8 = context.Items.Find(8);
            Item Item9 = context.Items.Find(9);
            Item Item10 = context.Items.Find(10);

            var listDetails = new List<ListDetail>
            {
                new ListDetail{List=list1,Item=Item1,ItemQty=3},
                new ListDetail{List=list1,Item=Item2,ItemQty=5},
                new ListDetail{List=list1,Item=Item4,ItemQty=1},
                new ListDetail{List=list1,Item=Item6,ItemQty=7},
                new ListDetail{List=list1,Item=Item9,ItemQty=9},

                new ListDetail{List=List2,Item=Item2,ItemQty=1},
                new ListDetail{List=List2,Item=Item7,ItemQty=3},
                new ListDetail{List=List2,Item=Item3,ItemQty=4},
                new ListDetail{List=List2,Item=Item9,ItemQty=3},
                new ListDetail{List=List2,Item=Item8,ItemQty=9},

                new ListDetail{List=List3,Item=Item1,ItemQty=3},
                new ListDetail{List=List3,Item=Item2,ItemQty=2},
                new ListDetail{List=List3,Item=Item4,ItemQty=4},
                new ListDetail{List=List3,Item=Item6,ItemQty=3},
                new ListDetail{List=List3,Item=Item5,ItemQty=3},

                new ListDetail{List=List4,Item=Item2,ItemQty=3},
                new ListDetail{List=List4,Item=Item7,ItemQty=6},
                new ListDetail{List=List4,Item=Item3,ItemQty=10},
                new ListDetail{List=List4,Item=Item4,ItemQty=12},
                new ListDetail{List=List4,Item=Item8,ItemQty=7},
                
                new ListDetail{List=List5,Item=Item2,ItemQty=4},
                new ListDetail{List=List5,Item=Item4,ItemQty=8},
                new ListDetail{List=List5,Item=Item3,ItemQty=13},
                new ListDetail{List=List5,Item=Item9,ItemQty=23},
                new ListDetail{List=List5,Item=Item5,ItemQty=7},
            };
            listDetails.ForEach(s => context.ListDetails.Add(s));
            context.SaveChanges();
        }
    }
}