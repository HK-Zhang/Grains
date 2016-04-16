using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.SelfHost.Channels;
using System.ServiceModel.Channels;
using System.Reflection;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;
using System.Linq.Expressions;
using System.Diagnostics;

namespace CsPoc.Network
{
    public class HttpBindingDemo
    {

        public void Execute() {
            Listen();
        }
        private void Listen() 
        {
            Uri listenUri = new Uri("http://127.0.0.1:3721");
            Binding binding = new HttpBinding();
            IChannelListener<IReplyChannel> channelListener = binding.BuildChannelListener<IReplyChannel>(listenUri);
            channelListener.Open();

            IReplyChannel channel = channelListener.AcceptChannel(TimeSpan.MaxValue);
            channel.Open();

            Stopwatch watch = new Stopwatch();
            while (true)
            {
                
                
                RequestContext requestContext = channel.ReceiveRequest(TimeSpan.MaxValue);
                watch.Start();
                PrintRequestMessage(requestContext.RequestMessage);
                requestContext.Reply(CreateResponseMessage());
                watch.Stop();
                Console.WriteLine("iterations {0} ms",watch.ElapsedMilliseconds);
                watch.Reset();
            }

        }

        private void PrintRequestMessage(Message message)
        {
            MethodInfo method = message.GetType().GetMethod("GetHttpRequestMessage");

            ////call via reflection
            //HttpRequestMessage request = (HttpRequestMessage)method.Invoke(message, new object[] { false });

            //call via dynamic object. it is not working due to GetHttpRequestMessage is an internal method
            //dynamic msg = message;
            //HttpRequestMessage request = msg.GetHttpRequestMessage(false);

            //call via expression tree
            ConstantExpression b = Expression.Constant(false, typeof(bool));
            MethodCallExpression methodCallexp = Expression.Call(Expression.Constant(message), method, b);
            Expression<Func<HttpRequestMessage>> getHttpRequestMessage = Expression.Lambda<Func<HttpRequestMessage>>(methodCallexp);
            HttpRequestMessage request = getHttpRequestMessage.Compile()();


            Console.WriteLine("{0,-15}:{1}", "RequestUri", request.RequestUri);

            foreach (var header in request.Headers)
            {
                Console.WriteLine("{0,-15}:{1}", header.Key, string.Join(",",header.Value.ToArray()));
            }
        }

        private Message CreateResponseMessage()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            Employee employee = new Employee(123, "Henry", "234", "123@123.com");
            response.Content = new ObjectContent<Employee>(employee, new JsonMediaTypeFormatter());


            String httpMessageTypeName = "System.Web.Http.SelfHost.Channels.HttpMessage,System.Web.Http.SelfHost";


            Type httpMessageType = Type.GetType(httpMessageTypeName);

            //call via expression tree
            ConstructorInfo cinfo = httpMessageType.GetConstructor(new[] { typeof(HttpResponseMessage) });
            ConstantExpression consResponse = Expression.Constant(response, typeof(HttpResponseMessage));
            NewExpression newExp = Expression.New(cinfo, consResponse);
            Expression<Func<Message>> lambdaExp = Expression.Lambda<Func<Message>>(newExp, null);
            return lambdaExp.Compile()();

            ////call via reflection
            //return (Message)Activator.CreateInstance(httpMessageType, new object[] { response });
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoNo { get; set; }
        public string EmailAddress { get; set; }

        public Employee(int id,string name,string photoNo,string emailAddress)
        {
            Id = id;
            Name = name;
            PhotoNo = photoNo;
            EmailAddress = emailAddress;
        }
    }
}
