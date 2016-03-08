using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    public class ImmutableDemo
    {
        public void Excecute()
        {
            //Foo1();
            //Foo2();
            //Foo3();
            Foo4();
        }

        private void Foo1() {
            var color1 = ImmutableArray.Create("orange", "red", "blue");
            var color2 = color1.Add("green");
            color1.ToList().ForEach((c)=>Console.WriteLine(c));
            color2.ToList().ForEach((c) => Console.WriteLine(c));
        }

        private void Foo2() 
        {
            var p1 = new Person { Name = "Henry" };
            var p2 = new Person { Name = "Gates" };

            var people1 = ImmutableArray.Create(p1);
            var people2 = people1.Add(p2);

            people1.ToList().ForEach((c) => Console.WriteLine(c.Name));
            people2.ToList().ForEach((c) => Console.WriteLine(c.Name));

            p1.Name = "Terry";

            people1.ToList().ForEach((c) => Console.WriteLine(c.Name));
            people2.ToList().ForEach((c) => Console.WriteLine(c.Name));
        }

        private void Foo3()
        {
            var color1 = ImmutableArray.Create("orange", "red", "blue");
            var color2Builder = color1.ToBuilder();
            color2Builder.Add("black");
            color2Builder.Add("white");
            var color2 = color2Builder.ToImmutable(); 
            color1.ToList().ForEach((c) => Console.WriteLine(c));
            color2.ToList().ForEach((c) => Console.WriteLine(c));
        }

        private void Foo4()
        {
            OrderLine apple = new OrderLine(quantity: 1, unitPrice: 2.5m, discount: 0.0f);
            Order order = new Order(ImmutableList.Create(apple));

            order.Lines.ToList().ForEach((c) => Console.WriteLine(c.Discount));

            OrderLine discountedApple = apple.WithDiscount(0.3f);
            Order discountedOrder = order.ReplaceLine(apple, discountedApple);
            discountedOrder.Lines.ToList().ForEach((c) => Console.WriteLine(c.Discount));
        }

    }

    class Order
    {
        public Order(IEnumerable<OrderLine> lines)
        {
            Lines = lines.ToImmutableList();
        }

        public ImmutableList<OrderLine> Lines { get; private set; }

        public Order WithLines(IEnumerable<OrderLine> value)
        {
            return Object.ReferenceEquals(Lines, value)
                ? this
                : new Order(value);
        }

        public Order AddLine(OrderLine value)
        {
            return WithLines(Lines.Add(value));
        }

        public Order RemoveLine(OrderLine value)
        {
            return WithLines(Lines.Remove(value));
        }

        public Order ReplaceLine(OrderLine oldValue, OrderLine newValue)
        {
            return oldValue == newValue
                    ? this
                    : WithLines(Lines.Replace(oldValue, newValue));
        }

    } 


    class OrderLine
    {
        public OrderLine(int quantity, decimal unitPrice, float discount)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; private set; }

        public float Discount { get; private set; }

        public decimal Total
        {
            get
            {
                return Quantity * UnitPrice * (decimal)(1.0f - Discount);
            }
        }

        public OrderLine WithQuantity(int value)
        {
            return value == Quantity
                    ? this
                    : new OrderLine(value, UnitPrice, Discount);
        }

        public OrderLine WithUnitPrice(decimal value)
        {
            return value == UnitPrice
                    ? this
                    : new OrderLine(Quantity, value, Discount);
        }

        public OrderLine WithDiscount(float value)
        {
            return value == Discount
                    ? this
                    : new OrderLine(Quantity, UnitPrice, value);
        }

    } 

}
