using System;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class TransformingBlock
    {
        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }


        private static void foo1()
        {
            // Create a TransformBlock<int, double> object that 
            // computes the square root of its input.
            var transformBlock = new TransformBlock<int, double>(n => Math.Sqrt(n));

            // Post several messages to the block.
            transformBlock.Post(10);
            transformBlock.Post(20);
            transformBlock.Post(30);

            // Read the output messages from the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(transformBlock.Receive());
            }

            /* Output:
               3.16227766016838
               4.47213595499958
               5.47722557505166
             */
        }
    }
}
