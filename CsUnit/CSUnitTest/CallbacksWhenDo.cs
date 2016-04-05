using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveTDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Exceptions;
using Shouldly;

namespace UnitTestTDD
{
    [TestClass]
    public class CallbacksWhenDo
    {
        [TestMethod]
        public void Test_CallbacksWhenDo_PassFunctionsToReturns()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter = 0;
            calculator
              .Add(0, 0)
              .ReturnsForAnyArgs(x => 0)
              .AndDoes(x => counter++);

            calculator.Add(7, 3);
            calculator.Add(2, 2);
            calculator.Add(11, -3);
            counter.ShouldBe(3);
            //Assert.AreEqual(counter, 3);
        }

        [TestMethod]
        public void Test_CallbacksWhenDo_UseWhenDo()
        {
            var counter = 0;
            var foo = Substitute.For<IFoo>();

            foo.When(x => x.SayHello("World"))
              .Do(x => counter++);

            foo.SayHello("World");
            foo.SayHello("World");
            counter.ShouldBe(2);
            //Assert.AreEqual(2, counter);
        }

        [TestMethod]
        public void Test_CallbacksWhenDo_UseWhenDoOnNonVoid()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter = 0;
            calculator.Add(1, 2).Returns(3);
            calculator
              .When(x => x.Add(Arg.Any<int>(), Arg.Any<int>()))
              .Do(x => counter++);

            var result = calculator.Add(1, 2);
            result.ShouldBe(3);
            counter.ShouldBe(1);
            //Assert.AreEqual(3, result);
            //Assert.AreEqual(1, counter);
        }
    }
}
