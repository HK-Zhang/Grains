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
    public class ReturnSubstitute
    {
        [TestMethod]
        public void Test_ReturnForSpecificArgs_UseArgumentsMatcher()
        {
            var calculator = Substitute.For<ICalculator>();

            // 当第一个参数是任意int类型的值，第二个参数是5时返回。
            calculator.Add(Arg.Any<int>(), 5).Returns(10);
            calculator.Add(123, 5).ShouldBe(10);
            //Assert.AreEqual(10, calculator.Add(123, 5));
            calculator.Add(-9, 5).ShouldBe(10);
            //Assert.AreEqual(10, calculator.Add(-9, 5));
            calculator.Add(-9, -9).ShouldNotBe(10);
            //Assert.AreNotEqual(10, calculator.Add(-9, -9));

            // 当第一个参数是1，第二个参数小于0时返回。
            calculator.Add(1, Arg.Is<int>(x => x < 0)).Returns(345);
            calculator.Add(1, -2).ShouldBe(345);
            //Assert.AreEqual(345, calculator.Add(1, -2));
            calculator.Add(1, 2).ShouldNotBe(345);
            //Assert.AreNotEqual(345, calculator.Add(1, 2));

            // 当两个参数都为0时返回。
            calculator.Add(Arg.Is(0), Arg.Is(0)).Returns(99);
            calculator.Add(0, 0).ShouldBe(99);
            //Assert.AreEqual(99, calculator.Add(0, 0));
        }

        [TestMethod]
        public void Test_ReturnForAnyArgs_ReturnForAnyArgs()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(1, 2).ReturnsForAnyArgs(100);
            calculator.Add(1, 2).ShouldBe(100);
            //Assert.AreEqual(calculator.Add(1, 2), 100);
            calculator.Add(-7, 15).ShouldBe(100);
            //Assert.AreEqual(calculator.Add(-7, 15), 100);
        }

        [TestMethod]
        public void Test_ReturnFromFunction_ReturnSum()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator
              .Add(Arg.Any<int>(), Arg.Any<int>())
              .Returns(x => (int)x[0] + (int)x[1]);

            //Assert.AreEqual(calculator.Add(1, 1), 2);
            calculator.Add(1, 1).ShouldBe(2);
            //Assert.AreEqual(calculator.Add(20, 30), 50);
            calculator.Add(20, 30).ShouldBe(50);
            //Assert.AreEqual(calculator.Add(-73, 9348), 9275);
            calculator.Add(-73, 9348).ShouldBe(9275);
        }

        [TestMethod]
        public void Test_ReturnFromFunction_CallInfo()
        {
            var foo = Substitute.For<IFoo>();
            foo.Bar(0, "").ReturnsForAnyArgs(x => "Hello " + x.Arg<string>());
            foo.Bar(1, "World").ShouldBe("Hello World");
            //Assert.AreEqual("Hello World", foo.Bar(1, "World"));
        }

        [TestMethod]
        public void Test_ReturnFromFunction_GetCallbackWhenever()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter = 0;
            calculator
              .Add(0, 0)
              .ReturnsForAnyArgs(x =>
              {
                  counter++;
                  return 0;
              });

            calculator.Add(7, 3);
            calculator.Add(2, 2);
            calculator.Add(11, -3);
            counter.ShouldBe(3);
            //Assert.AreEqual(counter, 3);
        }

        [TestMethod]
        public void Test_ReturnFromFunction_UseAndDoesAfterReturns()
        {
            var calculator = Substitute.For<ICalculator>();

            var counter = 0;
            calculator
              .Add(0, 0)
              .ReturnsForAnyArgs(x => 0)
              .AndDoes(x => counter++);

            calculator.Add(7, 3);
            calculator.Add(2, 2);
            counter.ShouldBe(2);
            //Assert.AreEqual(counter, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_MultipleReturnValues_UsingCallbacks()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns(x => "DEC", x => "HEX", x => { throw new Exception(); });
            calculator.Mode.ShouldBe("DEC");
            calculator.Mode.ShouldBe("HEX");
            var result = calculator.Mode;
        }

        [TestMethod]
        public void Test_ReplaceReturnValues_ReplaceSeveralTimes()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns("DEC,HEX,OCT");
            calculator.Mode.Returns(x => "???");
            calculator.Mode.Returns("HEX");
            calculator.Mode.Returns("BIN");

            calculator.Mode.ShouldBe("BIN");
        }



    }
}
