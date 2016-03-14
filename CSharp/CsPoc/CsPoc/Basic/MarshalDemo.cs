using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class MarshalDemo
    {
        public void Execute()
        {
            string assemblyName = Assembly.GetEntryAssembly().FullName;

            //为三个对象创建独立的应用程序域
            AppDomain appRef = AppDomain.CreateDomain("MarshalByRef Domain");
            AppDomain appValue = AppDomain.CreateDomain("MarshalByValue Domain");
            AppDomain appNon = AppDomain.CreateDomain("NonMarshal Domain");

            //当前应用程序域
            CallMethod();

            try
            {
                Console.WriteLine("**************************MarshalByRef**************************");

                //按引用封送
                MBR mbr = (MBR)appRef.CreateInstanceAndUnwrap(assemblyName, typeof(MBR).FullName);
                Console.WriteLine("MarshalByRefObject Created");

                //透明代理
                Console.WriteLine("Is TransparentProxy? {0}", RemotingServices.IsTransparentProxy(mbr));

                //调用
                mbr.CallMethod();

                //卸载应用程序域
                AppDomain.Unload(appRef);
                Console.WriteLine("MarshalByRef Domain Unloaded");

                //不能调用
                mbr.CallMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("**************************MarshalByValue**************************");

                //按值封送
                MBV mbv = (MBV)appValue.CreateInstanceAndUnwrap(assemblyName, typeof(MBV).FullName);
                Console.WriteLine("MarshalByValueObject Created");

                //不是透明代理
                Console.WriteLine("Is TransparentProxy? {0}", RemotingServices.IsTransparentProxy(mbv));

                //调用访问
                mbv.CallMethod();

                //卸载应用程序域
                AppDomain.Unload(appValue);
                Console.WriteLine("MarshalByValue Domain Unloaded");

                //可以继续访问
                mbv.CallMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("**************************NonMarshal**************************");

                //不封送，不能创建实例
                Non nm = (Non)appNon.CreateInstanceAndUnwrap(assemblyName, typeof(Non).FullName);
                nm.CallMethod();
                AppDomain.Unload(appNon);
                nm.CallMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        static void CallMethod()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Current AppDomain：{0}", currentDomain.FriendlyName);
        }
    }

    /// <summary>
    /// 按引用封送类
    /// </summary>
    public class MBR : MarshalByRefObject 
    {
        public void CallMethod()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("MBR AppDomain：{0}", currentDomain.FriendlyName);
        }
    }

    /// <summary>
    /// 按值封送类
    /// </summary>
    [Serializable]
    public class MBV
    {
        public void CallMethod()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("MBV AppDomain：{0}", currentDomain.FriendlyName);
        }
    }

    /// <summary>
    /// 不封送
    /// </summary>
    public class Non
    {
        public void CallMethod()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("Non AppDomain：{0}", currentDomain.FriendlyName);
        }
    }
}
