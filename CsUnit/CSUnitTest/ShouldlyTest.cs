using CSLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace CSUnitTest
{
    [TestClass]
    public class ShouldlyTest
    {
        [TestMethod]
        public void ShouldBe()
        {
            var theSimpsonsCat = new Cat() { Name = "Santas little helper" };
            theSimpsonsCat.Name.ShouldBe("Snowball 2");

        }

        [TestMethod]
        public void ShouldNotBe()
        {
            var theSimpsonsCat = new Cat() { Name = "Santas little helper" };
            theSimpsonsCat.Name.ShouldNotBe("Santas little helper");

        }

        [TestMethod]
        public void ShouldBeOfType()
        {
            var theSimpsonsDog = new Cat() { Name = "Santas little helper" };
            theSimpsonsDog.ShouldBeOfType<Dog>();

        }

        [TestMethod]
        public void IEnumerable_ShouldAllBe_Predicate()
        {
            var mrBurns = new Person() { Name = "Mr.Burns", Salary = 3000000 };
            var kentBrockman = new Person() { Name = "Homer", Salary = 3000000 };
            var homer = new Person() { Name = "Homer", Salary = 30000 };
            var millionares = new List<Person>() { mrBurns, kentBrockman, homer };

            millionares.ShouldAllBe(m => m.Salary > 1000000);
        }

        [TestMethod]
        public void IEnumerable_ShouldContain()
        {
            var mrBurns = new Person() { Name = "Mr.Burns", Salary = 3000000 };
            var kentBrockman = new Person() { Name = "Homer", Salary = 3000000 };
            var homer = new Person() { Name = "Homer", Salary = 30000 };
            var millionares = new List<Person>() { kentBrockman, homer };

            millionares.ShouldContain(mrBurns);
        }

        [TestMethod]
        public void IEnumerable_ShouldContain_Predicate()
        {
            var homer = new Person() { Name = "Homer", Salary = 30000 };
            var moe = new Person() { Name = "Moe", Salary = 20000 };
            var barney = new Person() { Name = "Barney", Salary = 0 };
            var millionares = new List<Person>() { homer, moe, barney };

            // Check if at least one element in the IEnumerable satisfies the predicate
            millionares.ShouldContain(m => m.Salary > 1000000);
        }

        [TestMethod]
        public void DynamicShouldHavePropertyTest()
        {
            var homerThinkingLikeFlanders = new ExpandoObject();
            DynamicShould.HaveProperty(homerThinkingLikeFlanders, "IAmABigFourEyedLameO");

        }

        [TestMethod]
        public void ShouldMatch()
        {
            var simpsonDog = new Dog() { Name = "Santas little helper" };
            simpsonDog.Name.ShouldMatch("Santas [lL]ittle Helper");
        }

        [TestMethod]
        public void ShouldBeNullOrEmpty()
        {
            var anonymousClanOfSlackJawedTroglodytes = new Person() { Name = "The Simpsons" };
            anonymousClanOfSlackJawedTroglodytes.Name.ShouldBeNullOrEmpty();

        }

        [TestMethod]
        public void ShouldNotContainKey()
        {
            var websters = new Dictionary<string, string>();
            websters.Add("Chazzwazzers", "What Australians would have called a bull frog.");

            websters.ShouldNotContainKey("Chazzwazzers");
        }

        [TestMethod]
        public void ShouldContainKey()
        {
            var websters = new Dictionary<string, string>();
            websters.Add("Chazzwazzers", "What Australians would have called a bull frog.");

            websters.ShouldContainKeyAndValue("Chazzwazzers", "What Australians would have called a bull frog.");
        }

        [TestMethod]
        public void CompleteIn()
        {
            var homer = new Person() { Name = "Homer", Salary = 30000 };
            var denominator = 1;
            Should.CompleteIn(() =>
            {
                Thread.Sleep(2000);
                var y = homer.Salary / denominator;
            }, TimeSpan.FromSeconds(1));
        }

        [TestMethod]
        public void ShouldThrowFuncOfTask()
        {
            var homer = new Person() { Name = "Homer", Salary = 30000 };
            var denominator = 1;
            Should.Throw<DivideByZeroException>(() =>
            {
                var task = Task.Factory.StartNew(() => { var y = homer.Salary / denominator; });
                return task;
            });
        }

        [TestMethod]
        public void ShouldNotThrowFuncOfTask()
        {
            var homer = new Person() { Name = "Homer", Salary = 30000 };
            var denominator = 0;
            Should.NotThrow(() =>
            {
                var task = Task.Factory.StartNew(() => { var y = homer.Salary / denominator; });
                return task;
            });
        }
    }
}
