using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsPoc.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection.Tests
{
    [TestClass()]
    public class DectionaryHelperTests
    {
        [TestMethod()]
        public void GetValueTest()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("abc", 5);
            int rst = dict.GetValue<int>("abc");
            int defaultrst = dict.GetValue<int>("abd");
            Assert.AreEqual(5, rst);
            Assert.AreEqual(0, defaultrst);
        }

        [TestMethod()]
        public void SetValueTest()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.SetValue("abc", 5);
            int rst = dict.GetValue<int>("abc");
            Assert.AreEqual(5, rst);

            dict.SetValue("abc", 6);
            rst = dict.GetValue<int>("abc");
            Assert.AreEqual(6, rst);
        }
    }
}