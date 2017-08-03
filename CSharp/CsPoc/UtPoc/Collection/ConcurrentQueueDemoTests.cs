using Microsoft.VisualStudio.TestTools.UnitTesting;
using CsPoc.Collection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CsPoc.Collection.Tests
{
    [TestClass()]
    public class ConcurrentQueueDemoTests
    {
        [TestMethod()]
        public void DequeueTest()
        {
            var a = new CQDT {Id = "a"};
            var b = new CQDT {Id = "b"};
            var c = new CQDT {Id = "c"};
            var d = new CQDT { Id = "c" };

            ConcurrentQueueDemo.queue.Enqueue(a);
            ConcurrentQueueDemo.queue.Enqueue(b);
            ConcurrentQueueDemo.queue.Enqueue(c);

            ConcurrentQueueDemo testObj = new ConcurrentQueueDemo();
            IEnumerable<CQDT> rst = testObj.Dequeue();
            a.ShouldBeOneOf(rst.ToArray());
            b.ShouldBeOneOf(rst.ToArray());
            c.ShouldBeOneOf(rst.ToArray());
            d.ShouldBeOneOf(rst.ToArray());
        }
    }
}