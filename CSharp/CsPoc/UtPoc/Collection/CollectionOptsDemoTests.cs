using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsPoc.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CsPoc.Collection.Tests
{
    [TestClass()]
    public class CollectionOptsDemoTests
    {
        [TestMethod()]
        public void ConcactArrayTest()
        {
            string[] source = new string[] { "a", "b", "c" };
            string[] target = new string[] { "d", "e", "f" };

            var t = new CollectionOptsDemo();
            var rst = t.ConcactArray(source, target);

            source.ShouldBeSubsetOf(rst);
            target.ShouldBeSubsetOf(rst);

        }

        [TestMethod()]
        public void SelectManyDemoTest()
        {
            List<Person> people = new List<Person>
            {
                new Person {PhoneNumber = new List<string> {"a", "b"}},
                new Person {PhoneNumber = new List<string> {"c", "d"}}
            };

            var t = new CollectionOptsDemo();
            var rst = t.SelectManyDemo(people);

            var e1 = new List<string> {"a", "b"};
            var e2 = new List<string> { "c", "d" };

            e1.ShouldBeSubsetOf(rst);
            e2.ShouldBeSubsetOf(rst);
        }
    }
}