using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcUpload;

namespace gRPCClient
{
    internal class UploadTest
    {
        private static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:50051", new GrpcChannelOptions { MaxReceiveMessageSize = 50 * 1024 * 1024, MaxSendMessageSize = 20 * 1024 * 1024 });

        public static async Task UnaryCallAsync()
        {

            var client = new Greeter.GreeterClient(channel);
            using var call = client.SayHelloAsync(new HelloRequest { Name = "a.png",Photo= ByteString.CopyFrom(File.ReadAllBytes(@"D:\Picture\Coating\P1160107.JPG")) }, deadline: DateTime.UtcNow.AddSeconds(50));
            var response = await call.ResponseAsync;
            Console.WriteLine("Greeting: " + response.Message);
        }


    }
}
