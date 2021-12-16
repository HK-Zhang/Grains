using Grpc.Core;
using Grpc.Net.Client;
using GrpcGreeter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPCClient
{
    internal class ClientTest
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:50051",new GrpcChannelOptions { MaxReceiveMessageSize = 50 * 1024 * 1024, MaxSendMessageSize = 20 * 1024 * 1024 });

        public static async Task UnaryCallAsync()
        {

            var client = new Greeter.GreeterClient(channel);
            var metadata = new Metadata {
                new Metadata.Entry("name", "somehost"),
                new Metadata.Entry("header2", "header value")
            };
            using var call = client.SayHelloAsync(new HelloRequest { Name = "World" }, headers: metadata, deadline: DateTime.UtcNow.AddSeconds(5));
            var headers = await call.ResponseHeadersAsync;
            var response = await call.ResponseAsync;
            var trailers = call.GetTrailers();
            Console.WriteLine("headers: " + headers.GetValue("name"));
            Console.WriteLine("Greeting: " + response.Message);
            Console.WriteLine("trailers: " + trailers.GetValue("name"));
        }

        public static async Task ServerStreamingCallAsync()
        {
            //var client = new Greeter.GreeterClient(channel);
            //using var call = client.SayHello(new HelloRequest { Name = "World" });

            //while (await call.ResponseStream.MoveNext())
            //{
            //    Console.WriteLine("Greeting: " + call.ResponseStream.Current.Message);
            //}
        }

        public static async Task ClientStreamingCallAsync()
        {
            var client = new Greeter.GreeterClient(channel);
            using var call = client.SayRequestStream();

            for (var i = 0; i < 3; i++)
            {
                await call.RequestStream.WriteAsync(new HelloRequest { Name = "World" });
            }

            await call.RequestStream.WriteAsync(new HelloRequest { Name = "end" });

            await call.RequestStream.CompleteAsync();
            var response = await call;
            Console.WriteLine($"Response: {response.Message}");

        }

        public static async Task BidirectionalStreamingCallAsync()
        {
            var client = new Greeter.GreeterClient(channel);
            using var call = client.SayRequestAndRespStream();

            Console.WriteLine("Starting background task to receive messages");
            var readTask = Task.Run(async () =>
            {
                await foreach (var response in call.ResponseStream.ReadAllAsync())
                {
                    Console.WriteLine(response.Message);
                }
            });

            Console.WriteLine("Starting to send messages");
            Console.WriteLine("Type a message to echo then press enter.");
            for (var i = 0; i < 3; i++)
            {
                await call.RequestStream.WriteAsync(new HelloRequest { Name = "World" });
            }

            Console.WriteLine("Disconnecting");
            await call.RequestStream.CompleteAsync();
            await readTask;
        }
    }
}
