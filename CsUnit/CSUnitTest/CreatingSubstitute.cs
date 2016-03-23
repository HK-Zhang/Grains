using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiveTDD;
using NSubstitute;
using NSubstitute.Exceptions;
using Shouldly;

namespace UnitTestTDD
{
    [TestClass]
    public class CreatingSubstitute
    {
        [TestMethod]
        public void Test_CreatingSubstitute_MultipleInterfaces()
        {
            var command = Substitute.For<ICommand, IDisposable>();

            var runner = new CommandRunner(command);
            runner.RunCommand();

            command.Received().Execute();
            ((IDisposable)command).Received().Dispose();
        }

        [TestMethod]
        public void Test_CreatingSubstitute_SpecifiedOneClassType()
        {
            var substitute = Substitute.For(
                  new[] { typeof(ICommand), typeof(IDisposable), typeof(SomeClassWithCtorArgs) },
                  new object[] { 5, "hello world" }
                );

            //substitute.ShouldBeOfType<ICommand>();
            //substitute.ShouldBeOfType<IDisposable>();
            //substitute.ShouldBeOfType<SomeClassWithCtorArgs>();

            substitute.ShouldBeAssignableTo<ICommand>();
            substitute.ShouldBeAssignableTo<IDisposable>();
            substitute.ShouldBeAssignableTo<SomeClassWithCtorArgs>();

            //Assert.IsInstanceOfType(substitute, typeof(ICommand));
            //Assert.IsInstanceOfType(substitute, typeof(IDisposable));
            //Assert.IsInstanceOfType(substitute, typeof(SomeClassWithCtorArgs));
        }

        [TestMethod]
        public void Test_CreatingSubstitute_ForDelegate()
        {
            var func = Substitute.For<Func<string>>();
            func().Returns("hello");
            //Assert.AreEqual<string>("hello", func());
            func().ShouldBe("hello");
        }
    }


}
