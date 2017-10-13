using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClassDemo.Models
{
    public class ItemPriority
    {
        [Key]
        public int PriorityId { set; get; }
        public string PriorityName { set; get; }

        //relationship one-to-many(many)
        public ICollection<TrackerItem> TrackerItems { get; set; }
    }


}