using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class BufferingBlocks
    {
        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }

        private static void foo1()
        {
            // Create a BufferBlock<int> object.
            var bufferBlock = new BufferBlock<int>();

            // Post several messages to the block.
            for (int i = 0; i < 3; i++)
            {
                bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            for (int i = 0; i < 4; i++)
            {
                Task.Run(() =>
                {
                    Console.WriteLine(bufferBlock.Receive());
                });
            }

            /* Output:
               0
               1
               2
             */
        }
    }
}
