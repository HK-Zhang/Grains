using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CorePoc.Basic
{
    public class Jsonfy
    {
        public static void Execute4()
        {
            Warrantys warrantys = new Warrantys()
            {
                TP = new List<Warranty> {
                    new Warranty { Level = 0, Capacity = 100 },
                    new Warranty { Level = 500, Capacity = 98 },
                    new Warranty { Level = 1000, Capacity = 95 },
                    new Warranty { Level = 2000, Capacity = 90 },
                    new Warranty { Level = 3000, Capacity = 85 },
                    new Warranty { Level = 4000, Capacity = 80 } },
                TO = new List<Warranty>{
                    new Warranty { Level = 0, Capacity = 100 },
                    new Warranty { Level = 500, Capacity = 98 },
                    new Warranty { Level = 1000, Capacity = 95 },
                    new Warranty { Level = 2000, Capacity = 90 },
                    new Warranty { Level = 3000, Capacity = 85 },
                    new Warranty { Level = 4000, Capacity = 80 } },
                Year = new List<Warranty>{
                    new Warranty { Level = 1, Capacity = 100 },
                    new Warranty { Level = 2, Capacity = 98 },
                    new Warranty { Level = 3, Capacity = 95 },
                    new Warranty { Level = 4, Capacity = 90 },
                    new Warranty { Level = 5, Capacity = 85 },
                    new Warranty { Level = 6, Capacity = 80 } },
            };

            var result = JsonConvert.SerializeObject(warrantys);
        }

        public static void Execute()
        {
            List<BatteryStructure> lst = new List<BatteryStructure>();

            for (int i = 1; i < 3; i++)
            {
                var arrayItem = new BatteryStructure
                {
                    Name = $"Array-{i}",
                    Children = new List<BatteryStructure>(),
                    ControlBalance = false,
                    Connection = "Independent"
                };

                for (int j = 1; j < 10; j++)
                {
                    var packItem = new BatteryStructure
                    {
                        Name = $"Pack-{j}",
                        Children = new List<BatteryStructure>(),
                        ControlBalance = false,
                        Connection = "Parallel"
                    };

                    for (int x = 1; x < 19; x++)
                    {
                        var moduleItem = new BatteryStructure
                        {
                            Name = $"Module-{x}",
                            Children = new List<BatteryStructure>(),
                            ControlBalance = true,
                            Connection = "Series"

                        };

                        for (int y = 1; y < 13; y++)
                        {
                            var cellItem = new BatteryStructure
                            {
                                Name = $"Cell-{y}",
                                Predictable = true,
                                ControlBalance = false,
                                Connection = "Series"
                            };

                            moduleItem.Children.Add(cellItem);
                        }

                        packItem.Children.Add(moduleItem);
                    }

                    arrayItem.Children.Add(packItem);

                }

                lst.Add(arrayItem);
            }

            var result = JsonConvert.SerializeObject(lst);
        }

        public static void Execute2()
        {
            var httpResponseString = System.IO.File.ReadAllText("histogram10-1,4.json");
            var result = JsonConvert.DeserializeObject<IEnumerable<CycleHistogram>>(httpResponseString);
        }
    }

    public class HistogramPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    public class CycleHistogram
    {
        public string Name { get; set; }
        public IEnumerable<HistogramPoint> Points { get; set; }
    }

    public class BatteryStructure
    {
        public string Name { get; set; }
        public bool Predictable { get; set; }
        public List<BatteryStructure> Children { get; set; }

        public string Connection { get; set; }
        public bool ControlBalance { get; set; }
    }

    public class Warrantys
    {
        public IEnumerable<Warranty> TP { get; set; }
        public IEnumerable<Warranty> TO { get; set; }
        public IEnumerable<Warranty> Year { get; set; }
    }
    public class Warranty
    {
        public double Level { get; set; }
        public double Capacity { get; set; }
    }
}
