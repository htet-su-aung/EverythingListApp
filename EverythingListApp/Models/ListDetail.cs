using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverythingListApp.Models
{
    public class ListDetail
    {
        [Key]
        [Column(Order = 1)]
        public int ItemID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ListID { get; set; }
        public int ItemQty { get; set; }
    }
}