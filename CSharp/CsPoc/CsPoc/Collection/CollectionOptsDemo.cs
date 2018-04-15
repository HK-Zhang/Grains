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
           var a=  new Person {PhoneNumber = new List<string> {"a", "c","b"}};
            a.PhoneNumber = a.PhoneNumber.OrderBy(t => t).ToList();


            a.PhoneNumber.ForEach(t => Console.WriteLine(t));

            List<Person> people = new List<Person>
            {
                new Person {PhoneNumber = new List<string> {"a", "c", "b" }},
                new Person {PhoneNumber = new List<string> {"c", "a", "d" }}
            };


            people.ForEach(t => t.PhoneNumber = t.PhoneNumber.OrderBy(p => p).ToList());

            people.ForEach(p => p.PhoneNumber.ForEach(t => Console.WriteLine(t)));

        }

        public void Foo1()
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
