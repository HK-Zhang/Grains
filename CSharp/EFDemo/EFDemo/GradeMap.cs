using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class GradeMap : EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            ToTable("Grade");
            HasKey(key => key.Id);
            HasRequired(p => p.Student).WithMany(p => p.Grades).HasForeignKey(p=>p.StudentId);

        }
    }
}
