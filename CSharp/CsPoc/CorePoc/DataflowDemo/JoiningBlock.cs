using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.DataflowDemo
{
    class JoiningBlock
    {
        public static void ExecuteAsync()
        {
            //foo();
            foo1();
        }


        private static void foo1()
        {
            // Create a JoinBlock<int, int, char> object that requires
            // two numbers and an operator.
            var joinBlock = new JoinBlock<int, int, char>();

            // Post two values to each target of the join.

            joinBlock.Target1.Post(3);
            joinBlock.Target1.Post(6);

            joinBlock.Target2.Post(5);
            joinBlock.Target2.Post(4);

            joinBlock.Target3.Post('+');
            joinBlock.Target3.Post('-');

            // Receive each group of values and apply the operator part
            // to the number parts.

            for (int i = 0; i < 2; i++)
            {
                var data = joinBlock.Receive();
                switch (data.Item3)
                {
                    case '+':
                        Console.WriteLine("{0} + {1} = {2}",
                           data.Item1, data.Item2, data.Item1 + data.Item2);
                        break;
                    case '-':
                        Console.WriteLine("{0} - {1} = {2}",
                           data.Item1, data.Item2, data.Item1 - data.Item2);
                        break;
                    default:
                        Console.WriteLine("Unknown operator '{0}'.", data.Item3);
                        break;
                }
            }

            /* Output:
               3 + 5 = 8
               6 - 4 = 2
             */
        }
    }
}
