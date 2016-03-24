using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRDemo.MyStartup))]

namespace SignalRDemo
{
    public class MyStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            //注册管道,使用默认的虚拟地址,根目录下的"/signalr",当然你也可以自己定义
            app.MapSignalR();
        }
    }
}
