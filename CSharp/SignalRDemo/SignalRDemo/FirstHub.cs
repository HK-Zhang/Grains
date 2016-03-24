using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDemo
{
    //Hub的别名,方便前台调用
    [HubName("getMessage")]
    public class FirstHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        //编写发送信息的方法
        public void SendMessage(string message)
        {
            //调用所有客户注册的本地的JS方法(broadcastMessage)
            Clients.All.broadcastMessage(message + DateTime.Now.ToString());
        } 

    }
}