using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class TransformingManyBlock
    {
        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }


        private static void foo1()
        {
            // Create a TransformManyBlock<string, char> object that splits
            // a string into its individual characters.
            var transformManyBlock = new TransformManyBlock<string, char>(
               s => s.ToCharArray());

            // Post two messages to the first block.
            transformManyBlock.Post("Hello");
            transformManyBlock.Post("World");

            // Receive all output values from the block.
            for (int i = 0; i < ("Hello" + "World").Length; i++)
            {
                Console.WriteLine(transformManyBlock.Receive());
            }

            /* Output:
               H
               e
               l
               l
               o
               W
               o
               r
               l
               d
             */
        }
    }
}
