using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class BatchingBlock
    {
        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }

        private static void foo1()
        {
            // Create a BatchBlock<int> object that holds ten
            // elements per batch.
            var batchBlock = new BatchBlock<int>(10);

            // Post several values to the block.
            for (int i = 0; i < 13; i++)
            {
                batchBlock.Post(i);
            }
            // Set the block to the completed state. This causes
            // the block to propagate out any any remaining
            // values as a final batch.
            batchBlock.Complete();

            // Print the sum of both batches.

            Console.WriteLine("The sum of the elements in batch 1 is {0}.",
               batchBlock.Receive().Sum());

            Console.WriteLine("The sum of the elements in batch 2 is {0}.",
               batchBlock.Receive().Sum());

            /* Output:
               The sum of the elements in batch 1 is 45.
               The sum of the elements in batch 2 is 33.
             */
        }
    }
}
