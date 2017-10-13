using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassDemo.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<TrackerItem> TrackerItems { get; set; }
    }
}