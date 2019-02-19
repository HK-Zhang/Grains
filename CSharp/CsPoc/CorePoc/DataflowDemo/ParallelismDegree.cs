using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    public class ParallelismDegree
    {
        // Performs several computations by using dataflow and returns the elapsed
        // time required to perform the computations.
        static TimeSpan TimeDataflowComputations(int maxDegreeOfParallelism,
           int messageCount)
        {
            // Create an ActionBlock<int> that performs some work.
            var workerBlock = new ActionBlock<int>(
               // Simulate work by suspending the current thread.
               millisecondsTimeout => Thread.Sleep(millisecondsTimeout),
               // Specify a maximum degree of parallelism.
               new ExecutionDataflowBlockOptions
               {
                   MaxDegreeOfParallelism = maxDegreeOfParallelism
               });

            // Compute the time that it takes for several messages to 
            // flow through the dataflow block.

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < messageCount; i++)
            {
                workerBlock.Post(1000);
            }
            workerBlock.Complete();

            // Wait for all messages to propagate through the network.
            workerBlock.Completion.Wait();

            // Stop the timer and return the elapsed number of milliseconds.
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static void ExecuteAsync()
        {
            Foo1();
        }
        private static void Foo1()
        {
            int processorCount = Environment.ProcessorCount;
            int messageCount = processorCount;

            // Print the number of processors on this computer.
            Console.WriteLine("Processor count = {0}.", processorCount);

            TimeSpan elapsed;

            // Perform two dataflow computations and print the elapsed
            // time required for each.

            // This call specifies a maximum degree of parallelism of 1.
            // This causes the dataflow block to process messages serially.
            elapsed = TimeDataflowComputations(1, messageCount);
            Console.WriteLine("Degree of parallelism = {0}; message count = {1}; " +
               "elapsed time = {2}ms.", 1, messageCount, (int)elapsed.TotalMilliseconds);

            // Perform the computations again. This time, specify the number of 
            // processors as the maximum degree of parallelism. This causes
            // multiple messages to be processed in parallel.
            elapsed = TimeDataflowComputations(processorCount, messageCount);
            Console.WriteLine("Degree of parallelism = {0}; message count = {1}; " +
               "elapsed time = {2}ms.", processorCount, messageCount, (int)elapsed.TotalMilliseconds);
        }
    }
}
