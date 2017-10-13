using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassDemo.Models
{
    public class ItemTrackerStatus
    {
        public int ID { set; get; }
        public int ItemId { set; get; }
        public string Status { set; get; }
        public DateTime StatusDateTime { set; get; }
        public bool Enabled { set; get; }
    }
}