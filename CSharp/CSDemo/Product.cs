using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    class Product
    {
        private string name;
        public int ID { get; set; }

        public void ShowProduct() 
        {
            System.Console.WriteLine("Name={0},ID={1}", name, ID);
        }
    }
}
