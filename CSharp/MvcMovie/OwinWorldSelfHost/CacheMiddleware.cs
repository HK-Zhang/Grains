using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OwinWorldSelfHost
{
    public class CacheMiddleware : OwinMiddleware
    {
        private readonly IDictionary<string, CacheItem> _responseCache = new Dictionary<string, CacheItem>(); //Cache存储的字典

        public CacheMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            context.Environment["caching.addToCache"] = new Action<IOwinContext, string, TimeSpan>(AddToCache);
            var path = context.Request.Path.Value;

            //如果访问的路径没有缓存，就传递到OWIN管道的下一层中处理

            if (!_responseCache.ContainsKey(path))
            {
                return Next.Invoke(context);
            }
            var cacheItem = _responseCache[path];

            //检查缓存是否到期
            if (cacheItem.ExpiryTime <= DateTime.Now)
            {
                _responseCache.Remove(path);
                return Next.Invoke(context);
            }

            //直接从缓存中输出，而不是重新render页面
            context.Response.Write(cacheItem.Response);
            return Task.FromResult(0);
        }

        //添加cache的方法，将会以委托的方式存放到OWIN管道字典中，这样任何OWIN的Middleware都能够调用，从而保存数据到缓存

        public void AddToCache(IOwinContext context, string response, TimeSpan cacheDuration)
        {
            _responseCache[context.Request.Path.Value] = new CacheItem { Response = response, ExpiryTime = DateTime.Now + cacheDuration };
        }

        private class CacheItem
        {
            public string Response { get; set; }//保存缓存的内容
            public DateTime ExpiryTime { get; set; }//确定缓存的时间
        }

    }
}