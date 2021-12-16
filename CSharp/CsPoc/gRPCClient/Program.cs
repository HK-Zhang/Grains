// See https://aka.ms/new-console-template for more information
using gRPCClient;

Console.WriteLine("Hello, gRPC!");
//await ClientTest.UnaryCallAsync();
//await ClientTest.ServerStreamingCallAsync();
//await ClientTest.ClientStreamingCallAsync();
//await ClientTest.BidirectionalStreamingCallAsync();
await UploadTest.UnaryCallAsync();