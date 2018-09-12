using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class RecordOfSaleC
    {
        public int RecordOfSaleCId { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }

        public string CarState { get; set; }
        public string CarLicensePlate { get; set; }
        public CarC Car { get; set; }
    }
}
