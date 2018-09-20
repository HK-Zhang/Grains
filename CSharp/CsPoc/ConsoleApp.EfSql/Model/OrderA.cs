using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class OrderA
    {
        public int Id { get; set; }
        public StreetAddress ShippingAddress { get; set; }
    }
}
