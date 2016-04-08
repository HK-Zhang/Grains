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
    public class AutoRecursiveMocks
    {
        [TestMethod]
        public void Test_AutoRecursiveMocks_ManuallyCreateSubstitutes()
        {
            var factory = Substitute.For<INumberParserFactory>();
            var parser = Substitute.For<INumberParser>();
            factory.Create(',').Returns(parser);
            parser.Parse("an expression").Returns(new int[] { 1, 2, 3 });

            var actual = factory.Create(',').Parse("an expression");
            actual.ShouldBe(new int[] { 1, 2, 3 });
            //CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, actual);
        }

        [TestMethod]
        public void Test_AutoRecursiveMocks_AutomaticallyCreateSubstitutes()
        {
            var factory = Substitute.For<INumberParserFactory>();
            factory.Create(',').Parse("an expression").Returns(new int[] { 1, 2, 3 });

            var actual = factory.Create(',').Parse("an expression");

            actual.ShouldBe(new int[] { 1, 2, 3 });
            //CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, actual);
        }

        [TestMethod]
        public void Test_AutoRecursiveMocks_CallRecursivelySubbed()
        {
            var factory = Substitute.For<INumberParserFactory>();
            factory.Create(',').Parse("an expression").Returns(new int[] { 1, 2, 3 });

            var firstCall = factory.Create(',');
            var secondCall = factory.Create(',');
            var thirdCallWithDiffArg = factory.Create('x');

            secondCall.ShouldBe(firstCall);
            //Assert.AreSame(firstCall, secondCall);
            firstCall.ShouldNotBe(thirdCallWithDiffArg);
            //Assert.AreNotSame(firstCall, thirdCallWithDiffArg);
        }

        [TestMethod]
        public void Test_AutoRecursiveMocks_SubstituteChains()
        {
            var context = Substitute.For<IContext>();
            context.CurrentRequest.Identity.Name.Returns("My pet fish Eric");

            context.CurrentRequest.Identity.Name.ShouldBe("My pet fish Eric");
            //Assert.AreEqual(
            //  "My pet fish Eric",
            //  context.CurrentRequest.Identity.Name);
        }

        [TestMethod]
        public void Test_AutoRecursiveMocks_AutoValues()
        {
            var identity = Substitute.For<IIdentity>();
            identity.Name.ShouldBe(string.Empty);
            identity.Roles().Length.ShouldBe(0);
            //Assert.AreEqual(string.Empty, identity.Name);
            //Assert.AreEqual(0, identity.Roles().Length);
        }
    }
}
