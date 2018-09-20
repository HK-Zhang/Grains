using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class OrderDetails
    {
        public StreetAddress BillingAddress { get; set; }
        public StreetAddress ShippingAddress { get; set; }
    }
}
