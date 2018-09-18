using EverythingListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.ViewModels
{
    public class ListItemVM
    {
        public ListItemVM(List list, List<ListDetail> listDetails)
        {
            this.ListID = list.ListID;
            this.ListName = list.ListName;
            this.ListDescription = list.ListDescription;
            this.PplQty = list.PplQty;
            this.Location = list.Location;
            this.StartDate = list.StartDate;
            this.EndDate = list.EndDate;
            this.Duration = list.Duration;
            this.Category = list.Category;
            ListDetails = listDetails;
        }

        public int ListID { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }

        public int PplQty { get; set; }

        public string Location { get; set; }

        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public int Duration { get; set; }

        public Category Category { get; set; }
        public List<ListDetail> ListDetails { get; set; }
    }
}