using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.Models
{
    public class List
    {

        public int ListID { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }

        
        public int PplQty { get; set; }
     
        public string Location { get; set; }
        
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public int Duration { get; set; }
        public Category Category { get; set; }
        public ApplicationUser UserID { get; set; }
        public ICollection<ListDetail> ListDetails { get; set; }
      

    }
}