using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class RecordOfSaleB
    {
        public int RecordOfSaleBId { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }

        public string CarLicensePlate { get; set; }
        public CarB Car { get; set; }
    }
}
