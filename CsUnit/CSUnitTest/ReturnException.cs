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
    public class ReturnException
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_ThrowingExceptions_ForVoid()
        {
            var calculator = Substitute.For<ICalculator>();

            // 对无返回值函数
            calculator.Add(-1, -1).Returns(x => { throw new Exception(); });

            // 抛出异常
            calculator.Add(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_ThrowingExceptions_ForNonVoidAndVoid()
        {
            var calculator = Substitute.For<ICalculator>();

            // 对有返回值或无返回值函数
            calculator
              .When(x => x.Add(-2, -2))
              .Do(x => { throw new Exception(); });

            // 抛出异常
            calculator.Add(-2, -2);
        }
    }
}
