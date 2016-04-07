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
using System.ComponentModel;

namespace UnitTestTDD
{
    [TestClass]
    public class RaisingEvents
    {
        [TestMethod]
        public void Test_RaisingEvents_RaiseEvent()
        {
            var engine = Substitute.For<IEngine>();

            var wasCalled = false;
            engine.Idling += (sender, args) => wasCalled = true;

            // 告诉替代实例引发异常，并携带指定的sender和事件参数
            engine.Idling += Raise.EventWith(new object(), new EventArgs());

            wasCalled.ShouldBeTrue();

            //Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void Test_RaisingEvents_RaiseEventButNoMindSenderAndArgs()
        {
            var engine = Substitute.For<IEngine>();

            var wasCalled = false;
            engine.Idling += (sender, args) => wasCalled = true;

            engine.Idling += Raise.Event();
            wasCalled.ShouldBeTrue();
            //Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void Test_RaisingEvents_ArgsDoNotHaveDefaultCtor()
        {
            var engine = Substitute.For<IEngine>();

            int numberOfEvents = 0;
            engine.LowFuelWarning += (sender, args) => numberOfEvents++;

            // 发送事件，并携带指定的事件参数，未指定发送者
            engine.LowFuelWarning += Raise.EventWith(new LowFuelWarningEventArgs(10));
            // 发送事件，并携带指定的事件参数，并指定发送者
            engine.LowFuelWarning += Raise.EventWith(new object(), new LowFuelWarningEventArgs(10));

            numberOfEvents.ShouldBe(2);
            //Assert.AreEqual(2, numberOfEvents);
        }

        [TestMethod]
        public void Test_RaisingEvents_RaisingDelegateEvents()
        {
            var sub = Substitute.For<INotifyPropertyChanged>();
            bool wasCalled = false;

            sub.PropertyChanged += (sender, args) => wasCalled = true;

            sub.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(
              this, new PropertyChangedEventArgs("test"));

            wasCalled.ShouldBeTrue();
            //Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void Test_RaisingEvents_RaisingActionEvents()
        {
            var engine = Substitute.For<IEngine>();

            int revvedAt = 0;
            engine.RevvedAt += rpm => revvedAt = rpm;

            engine.RevvedAt += Raise.Event<Action<int>>(123);

            revvedAt.ShouldBe(123);
            //Assert.AreEqual(123, revvedAt);
        }
    }
}
