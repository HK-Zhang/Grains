using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class OrderC
    {
        public int Id { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public OrderStatus Status { get; set; }

    }

    public enum OrderStatus
    {
        Pending,
        Shipped
    }
}
