using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Relationships
{
    public class CarC
    {
        public int CarCId { get; set; }
        public string State { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public List<RecordOfSaleC> SaleHistory { get; set; }
    }
}
