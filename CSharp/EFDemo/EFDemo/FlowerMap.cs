using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class FlowerMap : EntityTypeConfiguration<Flower>
    {
        public FlowerMap()
        {
            ToTable("Flower");
            HasKey(key=>key.Id);
        }
    }
}
