using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ClassDemo.Context;
using System.ComponentModel.DataAnnotations;

namespace ClassDemo.Models
{
    public class ItemCategory
    {
        [Key]
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }

        public virtual ICollection<TrackerItem> TrackerItems { get; set; }
    }
   
}