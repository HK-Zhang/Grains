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
    public class SetOutRefArgs
    {
        [TestMethod]
        public void Test_SetOutRefArgs_SetOutArg()
        {
            // Arrange
            var value = "";
            var lookup = Substitute.For<ILookup>();
            lookup
              .TryLookup("hello", out value)
              .Returns(x =>
              {
                  x[1] = "world!";
                  return true;
              });

            // Act
            var result = lookup.TryLookup("hello", out value);

            // Assert
            result.ShouldBeTrue();
            //Assert.IsTrue(result);
            value.ShouldBe("world!");
            //Assert.AreEqual(value, "world!");
        }
    }
}
