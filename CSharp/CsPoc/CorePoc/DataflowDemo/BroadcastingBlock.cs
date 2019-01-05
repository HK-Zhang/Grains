using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class BroadcastingBlock
    {
        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }

        private static void foo1()
        {
            // Create a BroadcastBlock<double> object.
            var broadcastBlock = new BroadcastBlock<double>(null);

            // Post a message to the block.
            broadcastBlock.Post(Math.PI);

            // Receive the messages back from the block several times.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(broadcastBlock.Receive());
            }

            /* Output:
               3.14159265358979
               3.14159265358979
               3.14159265358979
             */
        }
    }
}
