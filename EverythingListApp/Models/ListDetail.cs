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
        public ListDetail(int itemID, int listID)
        {
            ItemID = itemID;
            ListID = listID;
        }

        public ListDetail(int itemID, int itemQty, int listID)
        {
            ItemID = itemID;
            ListID = listID;
            ItemQty = itemQty;
        }
        public ListDetail()
        {
            }

        [Key, Column(Order = 0)]
        public int ItemID { get; set; }

        [Key, Column(Order = 1)]
        public int ListID { get; set; }
        public int ItemQty { get; set; }

        public virtual List List { get; set; }
        public virtual Item Item { get; set; }
    }
}