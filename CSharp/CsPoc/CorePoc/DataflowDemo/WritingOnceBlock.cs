using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class WritingOnceBlock
    {
        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }

        private static void foo1()
        {
            // Create a WriteOnceBlock<string> object.
            var writeOnceBlock = new WriteOnceBlock<string>(null);

            // Post several messages to the block in parallel. The first 
            // message to be received is written to the block. 
            // Subsequent messages are discarded.
            Parallel.Invoke(
               () => writeOnceBlock.Post("Message 1"),
               () => writeOnceBlock.Post("Message 2"),
               () => writeOnceBlock.Post("Message 3"));

            // Receive the message from the block.
            Console.WriteLine(writeOnceBlock.Receive());

            /* Sample output:
               Message 2
             */
        }
    }
}
