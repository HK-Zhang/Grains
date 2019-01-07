using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class ActionBlockDemo
    {

        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }


        private static void foo1()
        {
            // Create an ActionBlock<int> object that prints values
            // to the console.
            var actionBlock = new ActionBlock<int>(n => Console.WriteLine(n));

            // Post several messages to the block.
            for (int i = 0; i < 3; i++)
            {
                actionBlock.Post(i * 10);
            }

            // Set the block to the completed state and wait for all 
            // tasks to finish.
            actionBlock.Complete();
            actionBlock.Completion.Wait();

            /* Output:
               0
               10
               20
             */
        }
    }
}
