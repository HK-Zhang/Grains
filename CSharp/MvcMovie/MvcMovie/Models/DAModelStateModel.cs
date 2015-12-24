using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class DAModelStateModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage="Email is reuqired")]
        [RegularExpression(@"^\s*([A-Za-z0-9_-]+(\.\w+)*@([\w-]+\.)+\w{2,3})\s*$", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
    }
}