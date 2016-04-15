using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    [ComplexType]
    public class DepartmentDetail
    {
        [MaxLength(250)]
        public string History { get; set; }
    }
}
