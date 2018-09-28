using EverythingListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.ViewModels
{
    public class ListWithFavoriteVM
    {
        public ListWithFavoriteVM(List l)
        {
            ListID = l.ListID;
            ListName = l.ListName;
            ListDescription = l.ListDescription;
            PplQty = l.PplQty;
            Location = l.Location;
            StartDate = l.StartDate;
            EndDate = l.EndDate;
            Duration = l.Duration;
            CategoryName = l.Category.CategoryName;
            UserName = (l.User != null) ? l.User.UserName : "";
        }

        public int ListID { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }


        public int PplQty { get; set; }

        public string Location { get; set; }

        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public int Duration { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }

        public bool Favorite { get; set; }
    }
}