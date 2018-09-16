using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EverythingListApp.Models.ViewModels
{
    public class DetailViewModel
    {
        public int ListID { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }


        public int PplQty { get; set; }

        public string Location { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public Category Category { get; set; }
        public List<ListDetail> Listdetails { get; set; }

    }
}