using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo.Tests
{
    [TestClass()]
    public class Log4NetDemoTests
    {
        [TestMethod()]
        public void ExecuteTest()
        {
            Log4NetDemo t = new Log4NetDemo();
            t.Execute();
            Assert.IsTrue(true);
        }
    }
}