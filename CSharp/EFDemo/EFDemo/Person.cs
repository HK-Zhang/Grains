using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [InverseProperty("ChairMan")]
        public List<Department> DepartmentChairman { get; set; }

        [InverseProperty("Teacher")]
        public List<Department> DepartmentTeacher { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
