using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassDemo.Models
{
    public class Registration
    {
        [Key]
        public int RegId { get; set; }
        public int RoleId { get; set;}
        public string Name { get; set; }
        public string SurName { get; set; }
        public gender Gender { get; set; }
        public int age { get; set; }
        [RegularExpression ("^([+][9][1]|[9][1]|[0]){0,1}([7-9]{1})([0-9]{9})$")]
        public string MobileNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailId { get;set; }
        public string UserName { get; set;}
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public virtual Roles Role { get; set; }
    }
    public enum gender
    {
        male,
        female
    }
}