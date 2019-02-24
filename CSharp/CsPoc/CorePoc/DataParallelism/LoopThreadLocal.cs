using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorePoc.DataParallelism
{
    class LoopThreadLocal
    {
        public static void Execute()
        {
            Foo1();
        }

        private static void Foo1()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
            {
                subtotal += nums[j];
                return subtotal;
            },
                (x) => Interlocked.Add(ref total, x)
            );

            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Foo2()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(nums, // source collection
                                        () => 0, // method to initialize the local variable
                                        (j, loop, subtotal) => // method invoked by the loop on each iteration
                                     {
                                            subtotal += j; //modify local variable
                                         return subtotal; // value to be passed to next iteration
                                     },
                                        // Method to be executed when each partition has completed.
                                        // finalResult is the final value of subtotal for a particular partition.
                                        (finalResult) => Interlocked.Add(ref total, finalResult)
                                        );

            Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);

        }
    }
}
