using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class Department
    {
        // Primary key
        public int DepartmentID { get; set; }

        [ConcurrencyCheck,MaxLength(100)]
        public string Name { get; set; }

        //public string College { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        // Navigationproperty
        public virtual ICollection<Course> Courses { get; set; }

        public Person ChairMan { get; set; }
        public Person Teacher { get; set; }

    }
}
