using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using ClassDemo.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassDemo.Models
{
    public class ItemType
    {
        [Key]
        public int ItemTypeId { set; get; }
        public string ItemName { set; get; }

        public ICollection<TrackerItem> TrackerItems { get; set; }

    }
    
}