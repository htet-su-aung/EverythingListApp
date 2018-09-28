using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EverythingListApp.Models
{
    public class Favorite
    {
        [Key, Column(Order = 0)]
        public string UserID { get; set; }

        [Key, Column(Order = 1)]
        public int ListID { get; set; }

        public virtual List List { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}