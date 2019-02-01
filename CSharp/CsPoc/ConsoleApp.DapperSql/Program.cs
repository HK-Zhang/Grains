using ConsoleApp.DapperSql.Model;
using ConsoleApp.DapperSql.SQLite;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConsoleApp.DapperSql
{
    class Program
    {
        static void Main(string[] args)
        {

            //BasicSample();
            //MultiMapping();
            SQLiteDeom();

            Console.Read();
        }

        static void SQLiteDeom()
        {
            SqliteDemo.CreateAndOpenDb();
            SqliteDemo.SeedDatabase();
            SqliteDemo.GetAdmin();
        }
        static void BasicSample()
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
        }

        // Not a good sample, not working
        //todo :a bettersample http://www.cnblogs.com/yankliu-vip/p/4182892.html
        // http://www.cnblogs.com/elvinle/p/6050365.html
        static void MultiMapping()
        {
            using (IDbConnection dbConnection = new MySqlConnection("server=localhost;database=MySqlDbContext;uid=monty;pwd=123456;"))
            {
                var paisDictionary = new Dictionary<int, Pais>();
                var ufDictionary = new Dictionary<int, Uf>();


                dbConnection.Open();
                var a = dbConnection.Query<Pais, Uf, Cidade, Pais>("SELECT * FROM glb_pais INNER JOIN glb_uf ON glb_pais.Id=glb_uf.Id_GLB_Pais INNER JOIN glb_cidade ON glb_cidade.Id_GLB_UF=glb_uf.Id",
                    map:(pais,uf,cidade)=> {
                        Pais paisEntry;

                        if (!paisDictionary.TryGetValue(pais.Id, out paisEntry))
                        {
                            paisEntry = pais;
                            paisEntry.Ufs = new List<Uf>();
                            paisDictionary.Add(paisEntry.Id, paisEntry);
                        }

                        paisEntry.Ufs.Add(uf);

                        return paisEntry;
                    },
                    splitOn: "Id,Id_GLB_UF")
                    .ToList();
            }
        }
    }


}
