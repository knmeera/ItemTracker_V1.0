using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassDemo.Models
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}