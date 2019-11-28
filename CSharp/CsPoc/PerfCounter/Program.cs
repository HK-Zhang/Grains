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

            TelemetryConfiguration.Active.InstrumentationKey = "25bed5a8-9bfe-4907-90e0-65a4155ed7f9";
            _ = TelemetryConfiguration.Active;
//            
//            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
//            configuration.InstrumentationKey = "to be replaced";
//            var telemetryClient = new TelemetryClient(configuration);
//            telemetryClient.TrackTrace("Hello World5!");

            var perfCollectorModule = new PerformanceCollectorModule();
            perfCollectorModule.Counters.Add(new PerformanceCounterCollectionRequest(
                @"\Process(_Total)\Working Set", "Working Set"));
            perfCollectorModule.Counters.Add(new PerformanceCounterCollectionRequest(
                @"\LogicalDisk(_Total)\% Free Space", "Total Free Space"));
            perfCollectorModule.Counters.Add(new PerformanceCounterCollectionRequest(
                $@"\LogicalDisk({Environment.CurrentDirectory.Split(':')[0] + ":"})\% Free Space", "Free Space"));
            perfCollectorModule.Initialize(TelemetryConfiguration.Active);

//
//            telemetryClient.TrackTrace("Hello World6!");
//
//            telemetryClient.Flush();
            Console.WriteLine("Hello World6!");

            while (true)
            {
                Thread.Sleep(1000);
//                telemetryClient.Flush();

            }
            Console.ReadKey();
        }
    }
}
