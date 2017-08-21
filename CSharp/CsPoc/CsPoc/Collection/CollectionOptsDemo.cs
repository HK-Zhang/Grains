using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class CollectionOptsDemo
    {
        public string[] ConcactArray(string[] source, string[] target)
        {
            return source.Concat(target).ToArray();
        }

        public List<string> SelectManyDemo(List<Person> people)
        {
            return people.SelectMany(t => t.PhoneNumber).ToList();
        }

        public void Execute()
        {
            List<Person> people = new List<Person>
            {
                new Person {PhoneNumber = new List<string> {"a", "b"}},
                new Person {PhoneNumber = new List<string> {"c", "d"}}
            };

            var rst = SelectManyDemo(people);
        }
    }

    public class Person
    {
        public List<string> PhoneNumber { get; set; }

    }
}
