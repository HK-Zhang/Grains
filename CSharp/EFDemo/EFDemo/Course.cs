using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    [Table("TblCourse",Schema="dbo")]
    public class Course
    {
        // Primary key

        public int CourseID { get; set; }

        [Required]
        [MaxLength(100),MinLength(1)]
        public string Title { get; set; }

        [Column("Credit",TypeName="int")]
        public int Credits { get; set; }

        [NotMapped]
        public string Code {
            get {
                return CourseID + Title;
            }
        }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }


        // Foreign key
        public int DepartmentID { get; set; }


        [ForeignKey("DepartmentID")]
        // Navigationproperties
        public virtual Department Department { get; set; }

        public virtual ICollection<Person> Instructors { get; set; }

    }
}
