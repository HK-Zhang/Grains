using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FlowerId { get; set; }
        public virtual Flower Flower {get;set;}
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
