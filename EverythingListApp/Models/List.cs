using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.Models
{
    public class List
    {
        public List()
        {

        }
        public List(string listName, string listDescription, int pplQty, string location, DateTime? startDate, DateTime? endDate, int duration, int categoryID)
        {
            ListName = listName;
            ListDescription = listDescription;
            PplQty = pplQty;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            CategoryID = categoryID;
        }
        public List(int listID, string listName, string listDescription, int pplQty, string location, DateTime? startDate, DateTime? endDate, int duration, int categoryID)
        {
            ListID = listID;
            ListName = listName;
            ListDescription = listDescription;
            PplQty = pplQty;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            Duration = duration;
            CategoryID = categoryID;
        }

        public int ListID { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }

        
        public int PplQty { get; set; }
     
        public string Location { get; set; }
        
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public int Duration { get; set; }
        public int CategoryID { get; set; }
        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ListDetail> ListDetails { get; set; }

        public virtual ICollection<Favorite> Favorite { get; set; }

    }
}