using Microsoft.OData.Client;
using ODataApiClient.Default;
using ODataApiClient.ODataAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serviceUri = "http://localhost:33189/OData";
            var container = new Container(new Uri(serviceUri));

            container.Products.ToList().ForEach((p) => { Console.WriteLine("{0} {1} {2}", p.ID, p.Name, p.Price); });

            var pro = new Product { Name = "Client OData", Price = 1024, Category = "IT" };
            container.AddToProducts(pro);

            var response = container.SaveChanges(SaveChangesOptions.ReplaceOnUpdate);

            foreach (var operationResponse in response)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }


            container.Products.ToList().ForEach((p) => { Console.WriteLine("{0} {1} {2}", p.ID, p.Name, p.Price); });
            Console.Read(); 
        }
    }
}
