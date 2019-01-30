using System;
using System.Linq;

namespace ConsoleApp.DapperSql
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Repository();
            bank.Add(new Model.Product
            {
                Name = "Huawei P20",
                Price = 19,
                StockQty = 12
            });

            bank.GetAll().ToList().ForEach(t => Console.WriteLine($"{t.Name} - {t.Price} - {t.StockQty}"));

            var phone = bank.GetAll().FirstOrDefault();

            phone.Price = phone.Price + 1;

            bank.Update(phone);

            bank.GetAll().ToList().ForEach(t => Console.WriteLine($"{t.Name} - {t.Price} - {t.StockQty}"));

            Console.Read();
        }
    }
}
