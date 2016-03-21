﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiveTDD;
using NSubstitute;
using NSubstitute.Exceptions;
using Shouldly;

namespace UnitTestTDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            int actual = calculator.Add(1, 2);
            actual.ShouldBe(3);
            //Assert.AreEqual<int>(3, actual);
        }

        [TestMethod]
        public void Test_GetStarted_ReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2);

            calculator.Received().Add(1, 2);
            calculator.DidNotReceive().Add(5, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(ReceivedCallsException))]
        public void Test_GetStarted_DidNotReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(5, 7);

            calculator.Received().Add(1, 2);
        }

        [TestMethod]
        public void Test_GetStarted_SetPropertyValue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns("DEC");
            calculator.Mode.ShouldBe("DEC");
            //Assert.AreEqual<string>("DEC", calculator.Mode);

            calculator.Mode = "HEX";
            calculator.Mode.ShouldBe("HEX");
            //Assert.AreEqual<string>("HEX", calculator.Mode);
        }

        [TestMethod]
        public void Test_GetStarted_MatchArguments()
        {
            ICalculator calculator = Substitute.For<ICalculator>();

            calculator.Add(10, -5);

            calculator.Received().Add(Arg.Any<int>(), Arg.Is<int>(x => x < 0));
            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(10, Arg.Is<int>(x => x < 0));
        }

        [TestMethod]
        public void Test_GetStarted_PassFuncToReturns()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator
               .Add(Arg.Any<int>(), Arg.Any<int>())
               .Returns(x => (int)x[0] + (int)x[1]);

            int actual = calculator.Add(5, 10);
            actual.ShouldBe(15);

            //Assert.AreEqual<int>(15, actual);
        }

        [TestMethod]
        public void Test_GetStarted_MultipleValues()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Mode.Returns("HEX", "DEC", "BIN");

            calculator.Mode.ShouldBe("HEX");
            calculator.Mode.ShouldBe("DEC");
            calculator.Mode.ShouldBe("BIN");

            //Assert.AreEqual<string>("HEX", calculator.Mode);
            //Assert.AreEqual<string>("DEC", calculator.Mode);
            //Assert.AreEqual<string>("BIN", calculator.Mode);
        }

        [TestMethod]
        public void Test_GetStarted_RaiseEvents()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            bool eventWasRaised = false;

            calculator.PoweringUp += (sender, args) =>
            {
                eventWasRaised = true;
            };

            calculator.PoweringUp += Raise.Event();

            eventWasRaised.ShouldBeTrue();

            //Assert.IsTrue(eventWasRaised);
        }
    }
}
