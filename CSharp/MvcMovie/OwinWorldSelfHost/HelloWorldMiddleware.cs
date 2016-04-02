using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OwinWorldSelfHost
{
    public class HelloWorldMiddleware : OwinMiddleware
    {
        public HelloWorldMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            //var response = "Hello World! It is " + DateTime.Now;
            //context.Response.Write(response);
            //return Next.Invoke(context);

            var response = "Hello World! It is " + DateTime.Now;

            if (context.Environment.ContainsKey("caching.addToCache"))//这里直接从OWIN管道的字典中，检查是否有add cache, 如果存在，就将输出内容缓存到cache中，过期时间为10分钟。
            {
                var addToCache = (Action<IOwinContext, string, TimeSpan>)context.Environment["caching.addToCache"];
                addToCache(context, response, TimeSpan.FromMinutes(10));
            }

            context.Response.Write(response);
            return Task.FromResult(0);
        }
    }
}