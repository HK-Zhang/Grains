using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcMovie.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcMovie.DAL
{
    public class CompanyContext:DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public CompanyContext()
            : base("CompanyContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}