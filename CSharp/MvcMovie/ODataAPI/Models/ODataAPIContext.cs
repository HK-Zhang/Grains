using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ODataAPI.Models
{
    class ODataAPIContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ODataAPIContext()
            : base("ODataDB")
        {
        }
    }

}
