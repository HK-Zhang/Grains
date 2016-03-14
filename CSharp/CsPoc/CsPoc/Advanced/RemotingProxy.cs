using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class RemotingProxy
    {
        public void Execute()
        {
            try
            {
                User user = new User() { Name = "lee", PassWord = "123123123123" };
                UserProcessor userprocessor = TransparentProxy.Create<UserProcessor>();
                userprocessor.RegUser(user);
                Console.WriteLine(userprocessor.RegUser2(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    //RealProxy
    public class MyRealProxy<T> : RealProxy
    {
        private T _target;

        public MyRealProxy(T target)
            : base(typeof(T))
        {
            this._target = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            PreProceede(msg);

            IMethodCallMessage callMessage = (IMethodCallMessage)msg;

            //via reflection
            //object returnValue = callMessage.MethodBase.Invoke(this._target, callMessage.Args);

            //via Expression
            Type[] te = new Type[callMessage.Args.Count()];
            ConstantExpression[] ce = new ConstantExpression[callMessage.Args.Count()];


            for(int i=0;i<callMessage.Args.Count();++i)
            {
                te[i] = callMessage.Args[i].GetType();
                ce[i] = Expression.Constant(callMessage.Args[i], te[i]);
            }

            MethodInfo mthinfo = typeof(T).GetMethod(callMessage.MethodBase.Name, te);

            var parameter = Expression.Parameter(typeof(T), "obj");
            MethodCallExpression _methodCallexp = Expression.Call(Expression.Constant(this._target), mthinfo, ce);

            object returnValue = null;

            ParameterInfo pi = mthinfo.ReturnParameter;
            
            if (pi.ParameterType == typeof(void))
            {
                //no return value
                Expression<Action> consoleLambdaExp = Expression.Lambda<Action>(_methodCallexp);
                consoleLambdaExp.Compile()();
            }
            else 
            {
                //with return value
                Expression<Func<object>> consoleLambdaExp = Expression.Lambda<Func<object>>(_methodCallexp);
                returnValue = consoleLambdaExp.Compile()();
            }
  
            //end

            
          
            PostProceede(msg);

            return new ReturnMessage(returnValue, new object[0], 0, null, callMessage);
        }


        public void PreProceede(IMessage msg)
        {
            Console.WriteLine("Before call method");
        }
        public void PostProceede(IMessage msg)
        {
            Console.WriteLine("After call method");
        }
    }

    //TransparentProxy
    public static class TransparentProxy
    {
        public static T Create<T>()
        {
            T instance = Activator.CreateInstance<T>();
            MyRealProxy<T> realProxy = new MyRealProxy<T>(instance);
            T transparentProxy = (T)realProxy.GetTransparentProxy();
            return transparentProxy;
        }
    }

    public class User 
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
    }

    public interface IUserProcessor
    {
        void RegUser(User user);
    }

    public class UserProcessor : MarshalByRefObject, IUserProcessor
    {
        public void RegUser(User user)
        {
            Console.WriteLine("Already registered.");
        }

        public string RegUser2(User user)
        {
            Console.WriteLine("Already registered.");
            return "OK";
        }
    }
}
