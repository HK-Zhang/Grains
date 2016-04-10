namespace ODataRest.Migrations
{
    using ODataRest.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ODataRest.Models.ODataAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ODataRest.Models.ODataAPIContext";
        }

        protected override void Seed(ODataRest.Models.ODataAPIContext context)
        {
            context.Products.AddOrUpdate(new Product[] {
                new Product() { ID = 1, Name = "Hat", Price = 15, Category = "Apparel" },
                new Product() { ID = 2, Name = "Socks", Price = 5, Category = "Apparel" },
                new Product() { ID = 3, Name = "Scarf", Price = 12, Category = "Apparel" },
                new Product() { ID = 4, Name = "Yo-yo", Price = 4.95M, Category = "Toys" },
                new Product() { ID = 5, Name = "Puzzle", Price = 8, Category = "Toys" },
            });
        }
    }
}
