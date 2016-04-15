using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Student");
            HasKey(key => key.Id);
            HasOptional(p => p.Flower).WithMany(p => p.Students).HasForeignKey(p => p.FlowerId);
        }
    }
}
