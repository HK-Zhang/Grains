using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    /// <summary>
    /// Static and Thread Safety Interceptor Demo
    /// </summary>
    public class InterceptorDemo
    {
        public void Execute()
        {
            //Foo1();
            Foo2();
        }

        public void Foo1()
        {
            RealModel m = new RealModel();
            IModel rm = new DecoratorModel(m);
            rm.Foo1();
        }

        public void Foo2()
        {
            //Test for thread safety
            RealModel m = new RealModel();
            IModel rm = new DecoratorModel(m);
            Task.Run(new Action(() => rm.Foo1()));
            Task.Run(new Action(() => rm.Foo1()));
            Task.Run(new Action(() => rm.Foo1()));
            Task.Run(new Action(() => rm.Foo1()));
        }
    }

    public class LocalContext
    {
        public string MethodName { get; set; }
    }

    public interface IInterceptor
    {
        void Intercept(IComponentModel target);
    }

    public class LogInterceptor:IInterceptor
    {
        public void Intercept(IComponentModel target)
        {
            Console.WriteLine("Log: " + target.Context.MethodName);
            target.Proceed();
        }
    }

    public class FilterInterceptor : IInterceptor
    {
        public void Intercept(IComponentModel target)
        {
            Console.WriteLine("Filter: " + target.Context.MethodName);
            target.Proceed();
        }
    }

    public interface IComponentModel
    {
        LocalContext Context{get;}
        void Proceed();
    }

    public abstract class ComponentModel : IComponentModel
    {
        protected IList<IInterceptor> InterceptorList = new List<IInterceptor>();
        protected LocalContext Calcontext = new LocalContext();

        public void Proceed()
        {
            int i = 0;
            if (CallContext.GetData("index") == null)
            {
                CallContext.SetData("index", 0);
            }
            else {
                i = (int)CallContext.GetData("index");
                ++i;
                CallContext.SetData("index", i);
            }

            if (i < InterceptorList.Count)
                InterceptorList[i].Intercept(this);
        }


        public LocalContext Context
        {
            get
            {
                return Calcontext;
            }
        }
    }

    public interface IModel 
    {
        void Foo1();
    }

    public class DecoratorModel : ComponentModel, IModel
    {
        private IModel mdl;

        public DecoratorModel(IModel model)
        {
            mdl = model;
            InterceptorList.Add(new FilterInterceptor());
            InterceptorList.Add(new LogInterceptor());
        }

        public void Foo1()
        {
            this.Calcontext.MethodName = "Foo1";
            Proceed();
            mdl.Foo1();
        }
    }


    public class RealModel : IModel
    {
        public void Foo1()
        {
            Console.WriteLine("Foo1 is done");
        }
    }
}
