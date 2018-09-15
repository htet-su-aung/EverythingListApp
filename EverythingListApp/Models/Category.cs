using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<List> TBLists { get; set; }
    }
}