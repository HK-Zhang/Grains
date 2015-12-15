using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Simple
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "E_Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}