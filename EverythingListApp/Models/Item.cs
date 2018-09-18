using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public string ShopLink { get; set; }
        public virtual ICollection<ListDetail> ListDetails { get; set; }
    }
}