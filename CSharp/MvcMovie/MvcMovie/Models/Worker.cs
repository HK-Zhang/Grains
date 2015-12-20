using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public enum Sex { Male,Female}
    public class Worker
    {
        public int ID { get; set; }
        [Display(Name="First Name")]
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public Sex Sex{get;set;}
        public double? Rating{get;set;}

    }
}