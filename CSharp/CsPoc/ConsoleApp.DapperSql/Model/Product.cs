using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace ConsoleApp.DapperSql.Model
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQty { get; set; }
    }
}
