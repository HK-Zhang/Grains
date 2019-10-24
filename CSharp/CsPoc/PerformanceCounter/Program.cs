using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector;

namespace PerformanceCounter
{
    class Program
    {
        static void Main(string[] args)
        {

            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "replace with real value";


            var perfCollectorModule = new PerformanceCollectorModule();
            perfCollectorModule.Counters.Add(new PerformanceCounterCollectionRequest(
                @"\Memory\Available Bytes", "Available Bytes"));
            perfCollectorModule.Initialize(configuration);

            var telemetryClient = new TelemetryClient(configuration);
            telemetryClient.TrackTrace("Hello World4!");

            Console.WriteLine("Hello World2!");
            Console.ReadKey();
        }
    }
}
