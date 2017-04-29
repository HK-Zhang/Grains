using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Basic
{
    public class SteramIODemo
    {
        public void Execute()
        {
            ReadFromStream(WriteToStream());
        }

        private Stream WriteToStream()
        {
            var entries = new[] {
                new { FirstName = "Joe", LastName = "Smith", Email = "jsmith@example.com", Id = 1, PreferredContactNumber = "555-1212" },
                new { FirstName = "Hry", LastName = "Joe", Email = "abc@example.com", Id = 2, PreferredContactNumber = "555-1212" }
            };

            using (var stream = new MemoryStream())
            {
                using (var csvWriter = new StreamWriter(stream, Encoding.UTF8))
                {
                    csvWriter.WriteLine("First name,Second name,E-mail address,Preferred contact number,UserId");

                    foreach (var entry in entries)
                    {
                        csvWriter.WriteLine(String.Format("{0},{1},{2},{3},{4}",
                                                          entry.FirstName,
                                                          entry.LastName,
                                                          entry.Email,
                                                          entry.PreferredContactNumber,
                                                          entry.Id));
                    }

                    csvWriter.Flush();
                }

                return new MemoryStream(stream.ToArray());
            }
        }

        private void ReadFromStream(Stream s)
        {
            using (var sr = new StreamReader(s))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }

            }
        }

    }
}
