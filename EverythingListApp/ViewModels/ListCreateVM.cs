using EverythingListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.ViewModels
{
    public class ListCreateVM
    {
        public ListCreateVM()
        {
            ListDetailsQTY = new List<ListDetailsQTY>();
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

        public List<ListDetailsQTY> ListDetailsQTY { get; set; }

    }
}