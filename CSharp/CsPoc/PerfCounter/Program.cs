using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector;

namespace PerfCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            TelemetryConfiguration.Active.InstrumentationKey = "to be replaced";
            _ = TelemetryConfiguration.Active;
            
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "to be replaced";
            var telemetryClient = new TelemetryClient(configuration);
            telemetryClient.TrackTrace("Hello World5!");
            //
            //            var perfCollectorModule = new PerformanceCollectorModule();
            ////            perfCollectorModule.Counters.Add(new PerformanceCounterCollectionRequest(
            ////                @"\Memory\Available Bytes", "Available Bytes"));
            //            perfCollectorModule.Initialize(configuration);

            telemetryClient.TrackTrace("Hello World6!");

            telemetryClient.Flush();
            Console.WriteLine("Hello World6!");

            while (true)
            {
                Thread.Sleep(1000);
                telemetryClient.Flush();

            }
            Console.ReadKey();
        }
    }
}
