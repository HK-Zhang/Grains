using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq_Learning;

namespace CsPoc
{
    class LinqDemo
    {

        public static void RunDemo()
        {
            //Foo1();
           
            //Where_Query();
            //Where_Fluent();
            //Oftype_Fluent();

            //Foo2();

            //SelectMany_Query();
            //SelectMany_Fluent();

            //Order_Query();
            //Order_Fluent();
            //Reverse_Fluent();

            //Join_Query();
            //Join_Fluent();
            //GroupJoin_Query();
            //GroupJoin_Fluent();

            //Group_Query();
            //Group_Fluent();
            //Group_Fluent2();

            //Any_Fluent();

            //Paging_Query();

            //Intersect_Fluent();
            //Zip_Fluent();
            //SequenceEqual_Fluent();

            //ElementAt_Fluent();

            //Aggregate_Fluent();

            //DefaultIfEmpty_Fluent();

            //Lookup_Fluent();

            Range_Fluent();
        }

        private static void Foo1()
        {
            List<int> arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            //var result = arr.Where(a => { return a > 3; }).Sum();
            var result = (from v in arr where v > 3 select v).Sum();
            Console.WriteLine(result);
        }

        private static void Where_Query()
        {
            var racer = from r in Formula1.GetChampions()
                        where r.Wins > 15 && r.Country == "Austria"
                        select r;

            foreach (var item in racer)
            {
                Console.WriteLine("{0:A}",item);
            }
        }

        private static void Where_Fluent()
        {
            //var racer = Formula1.GetChampions().Where(r => { return r.Wins > 15 && r.Country == "Austria"; });
            var racer = Formula1.GetChampions().Where(r =>  r.Wins > 15 && r.Country == "Austria");

            foreach (var item in racer)
            {
                Console.WriteLine("{0:A}", item);
            }
        }

        private static void Oftype_Fluent()
        {
            object[] data = { "one", 2, 3, "four", "five", 6 };
            var query = data.OfType<string>();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        private static void Foo2()
        {
            string[] fullNames = { "Anne Williams", "John Fred Smith", "Sue Green" };

            IEnumerable<string> query = fullNames.SelectMany(name => name.Split());

            foreach (string name in query)
                Console.Write(name + "|");

            IEnumerable<string[]> query2 = fullNames.Select(name => name.Split());

            foreach (string[] stringArray in query2)
                foreach (string name in stringArray)
                    Console.Write(name + "|"); 
        }

        private static void SelectMany_Query()
        { 
            var ferrariDrivers = from r in Formula1.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r.FirstName + " " + r.LastName;

            foreach (var item in ferrariDrivers)
            {
                Console.WriteLine(item);
            }
        }

        private static void SelectMany_Fluent()
        { 
            var ferrariDrivers =Formula1.GetChampions()
                .SelectMany(
                r=>r.Cars,
                (r, c) => new { Racer = r, Car = c }
                )
                .Where(r=>r.Car=="Ferrari")
                .OrderBy(r=>r.Racer.LastName)
                .Select(r => r.Racer.FirstName + " " + r.Racer.LastName);

            foreach (var item in ferrariDrivers)
            {
                Console.WriteLine(item);
            }
        }

        private static void Order_Query()
        {
            var racer = from r in Formula1.GetChampions()
                         orderby r.Country, r.LastName descending, r.FirstName
                         select r;

            foreach (var item in racer)
            {
                Console.WriteLine(item);
            }
        }

        private static void Order_Fluent()
        {
            var racer = Formula1.GetChampions()
                .OrderBy(r => r.Country)
                .ThenByDescending(r => r.LastName)
                .ThenBy(r => r.FirstName);

            foreach (var item in racer)
            {
                Console.WriteLine(item);
            }
        }

        private static void Reverse_Fluent()
        {
            var racer = Formula1.GetChampions()
                .OrderBy(r => r.Country)
                .ThenByDescending(r => r.LastName)
                .ThenBy(r => r.FirstName)
                .Reverse();

            foreach (var item in racer)
            {
                Console.WriteLine(item);
            }
        }

        private static void Join_Query()
        {
            var racers = from r in Formula1.GetChampions()
                         from y in r.Years
                         where y > 1958 && y < 1965
                         select new
                         {
                             Year = y,
                             Name = r.FirstName + " " + r.LastName
                         };

            var teams = from t in Formula1.GetContructorChampions()
                        from y in t.Years
                        where y > 1958 && y < 1965
                        select new { Year = y, Name = t.Name };

            var racersAndTeams = from r in racers
                                 join t in teams on r.Year equals t.Year
                                 select new
                                 {
                                     Year = r.Year,
                                     Racer = r.Name,
                                     Team = t.Name
                                 };

            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}"
                    , item.Year, item.Racer, item.Team);
            }
        }

        private static void Join_Fluent()
        {
            var racers = Formula1.GetChampions()
               .SelectMany(y => y.Years, (r, y)
                   => new { Year = y, Name = r.FirstName + " " + r.LastName })
               .Where(ty => ty.Year > 1958 && ty.Year < 1965);

            var teams = Formula1.GetContructorChampions()
                .SelectMany(y => y.Years, (t, y) => new { Year = y, Name = t.Name })
                .Where(ty => ty.Year > 1958 && ty.Year < 1965);

            var racersAndTeams = racers.Join(teams
                  , r => r.Year, t => t.Year
                  , (r, t) => new { Year = r.Year, Racer = r.Name, Team = t.Name }
              );

            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}"
                    , item.Year, item.Racer, item.Team);
            }
        }

        private static void GroupJoin_Query()
        {
            var racers = from r in Formula1.GetChampions()
                         from y in r.Years
                         where y > 1958 && y < 1965
                         select new
                         {
                             Year = y,
                             Name = r.FirstName + " " + r.LastName
                         };

            var teams = from t in Formula1.GetContructorChampions()
                        from y in t.Years
                        where y > 1958 && y < 1965
                        select new { Year = y, Name = t.Name };

            var racersAndTeams = from r in racers
                                 join t in teams on r.Year equals t.Year
                                 into groupTeams
                                 select new
                                 {
                                     Year = r.Year,
                                     Racer = r.Name,
                                     GroupTeams = groupTeams
                                 };

            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}"
                    , item.Year, item.Racer, item.GroupTeams.Count());
            }
        }

        private static void GroupJoin_Fluent()
        {
            var racers = Formula1.GetChampions()
             .SelectMany(y => y.Years, (r, y)
                 => new { Year = y, Name = r.FirstName + " " + r.LastName })
             .Where(ty => ty.Year > 1958 && ty.Year < 1965);

            var teams = Formula1.GetContructorChampions()
                .SelectMany(y => y.Years, (t, y) => new { Year = y, Name = t.Name })
                .Where(ty => ty.Year > 1958 && ty.Year < 1965);

            var racersAndTeams = racers
                .GroupJoin(teams
                    , r => r.Year, t => t.Year
                    , (r, t) => new { Year = r.Year, Racer = r.Name, GroupTeams = t }
                );

            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}"
                    , item.Year, item.Racer, item.GroupTeams.Count());
            }
        }

        private static void Group_Query()
        {
            var result = from r in Formula1.GetChampions()
                         group r by r.Country into g
                         select new { Country = g.Key, Racers = g };

            foreach (var item in result)
            {
                Console.WriteLine("{0}\t\t{1}", item.Country, item.Racers.Count());
            }
        }

        private static void Group_Fluent()
        {
            var result = Formula1.GetChampions()
                .GroupBy(r => r.Country)
                .Select(g => new { Country = g.Key, Racers = g });

            foreach (var item in result)
            {
                Console.WriteLine("{0}\t\t{1}", item.Country, item.Racers.Count());
            }
        }

        private static void Group_Fluent2()
        {
            var result = Formula1.GetChampions()
                .GroupBy(r => r.Country, (k, g) => new { Country = k, Racers = g });


            foreach (var item in result)
            {
                Console.WriteLine("{0}\t\t{1}", item.Country, item.Racers.Count());
            }
        }

        private static void Any_Fluent()
        {
            var hasRacer_Schumacher = Formula1.GetChampions()
                .Any(r => r.LastName == "Schumacher");
            Console.WriteLine("是否存在姓为“Schumacher”的车手冠军？{0}", hasRacer_Schumacher ? "是" : "否");
        }

        private static void Paging_Query()
        {
            int pageSize = 5;

            int numberPages = (int)Math.Ceiling(
                Formula1.GetChampions().Count() / (double)pageSize);

            for (int page = 0; page < numberPages; page++)
            {
                Console.WriteLine("Page {0}", page);

                var racers = (
                              from r in Formula1.GetChampions()
                              orderby r.LastName
                              select r.FirstName + " " + r.LastName
                              )
                              .Skip(page * pageSize).Take(pageSize);

                foreach (var name in racers)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine();
            }
        }

        private static void Intersect_Fluent()
        {
            Func<string, IEnumerable<Racer>> racersByCar =
                car => from r in Formula1.GetChampions()
                       from c in r.Cars
                       where c == car
                       orderby r.LastName
                       select r;

            foreach (var racer in racersByCar("Ferrari").Intersect(racersByCar("McLaren")))
            {
                Console.WriteLine(racer);
            }
        }

        private static void Zip_Fluent()
        {
            string[] start = { "<html>", "<head>", "<body>" };
            string[] end = { "</html>", "</head>", "</body>" };

            var tags = start.Zip(end, (s, e) => { return s + e; });

            foreach (string item in tags)
            {
                Console.WriteLine(item);
            }
        }

        private static void SequenceEqual_Fluent()
        {
            int[] arr1 = { 1, 4, 7, 9 };
            int[] arr2 = { 1, 7, 9, 4 };
            Console.WriteLine("排序前 是否相等：{0}"
                , arr1.SequenceEqual(arr2) ? "是" : "否");  // 否
            Console.WriteLine();
            Console.WriteLine("排序后 是否相等：{0}"
                , arr1.SequenceEqual(arr2.OrderBy(k => k)) ? "是" : "否"); // 是
        }

        private static void ElementAt_Fluent()
        {
            var Racer3 = Formula1.GetChampions()
                .OrderByDescending(r => r.Wins)
                .ElementAtOrDefault(2);
            Console.WriteLine("获取冠军数排名第三的车手冠军为：{0} {1},获奖次数：{2}"
                , Racer3.LastName, Racer3.FirstName, Racer3.Wins);
        }

        private static void Sum_Fluent()
        {
            var racerCount = Formula1.GetChampions().Count();
        }

        private static void Aggregate_Fluent()
        {
            int[] numbers = { 1, 2, 3 };
            // 1+2+3 = 6
            int y = numbers.Aggregate((prod, n) => prod + n);
            // 0+1+2+3 = 6
            int x = numbers.Aggregate(0, (prod, n) => prod + n);
            // （0+1+2+3）*2 = 12
            int z = numbers.Aggregate(0, (prod, n) => prod + n, r => r * 2);
        }

        private static void DefaultIfEmpty_Fluent()
        {
            var defaultArrCount = (new int[0]).DefaultIfEmpty().Count(); // 1
            Console.WriteLine("空int数组的DefaultIfEmpty返回的集合元素个数为:{0}", defaultArrCount);
        }

        private static void Lookup_Fluent()
        {
            ILookup<string, Racer> racers =
                (from r in Formula1.GetChampions()
                 from c in r.Cars
                 select new
                 {
                     Car = c,
                     Racer = r
                 }
                 ).ToLookup(cr => cr.Car, cr => cr.Racer);

            if (racers.Contains("Williams"))
            {
                foreach (var williamsRacer in racers["Williams"])
                {
                    Console.WriteLine(williamsRacer);
                }
            }
        }

        private static void Range_Fluent()
        {
            var values = Enumerable.Range(1, 20);
            foreach (var item in values)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
    }
}
