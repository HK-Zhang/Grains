using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ODataRest.Models
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