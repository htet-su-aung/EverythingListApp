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
            ListDetailsQty = new List<ListDetailsQty>();
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

        public List<ListDetailsQty> ListDetailsQty { get; set; }

    }
}