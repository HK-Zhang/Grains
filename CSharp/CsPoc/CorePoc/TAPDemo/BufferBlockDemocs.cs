using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CorePoc.TAPDemo
{
    class BufferBlockDemocs
    {
        private static BufferBlock<int> m_data = new BufferBlock<int>();

        public static async Task ExecuteAsync()
        {
            foo1();
            //await foo2();
        }

        static async Task foo2()
        {
            Produce(1);
            Produce(2);

            Task.Run(ConsumerAsync);

            await Task.Delay(1000);
            Produce(3);
            Produce(4);
            //await ConsumerAsync();
        }

        private static async Task ConsumerAsync()
        {
            while (true)
            {
                int nextItem = await m_data.ReceiveAsync();
                ProcessNextItem(nextItem);
            }
        }

        private static void ProcessNextItem(int item)
        {
            Console.WriteLine(item);
        }

        private static void Produce(int data)
        {
            m_data.Post(data);
        }


        // Demonstrates asynchronous dataflow operations.
        static async Task AsyncSendReceive(BufferBlock<int> bufferBlock)
        {
            // Post more messages to the block asynchronously.
            for (int i = 0; i < 3; i++)
            {
                await bufferBlock.SendAsync(i);
            }

            // Asynchronously receive the messages back from the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(await bufferBlock.ReceiveAsync());
            }

            /* Output:
               0
               1
               2
             */
        }

        static void foo1()
        {
            // Create a BufferBlock<int> object.
            var bufferBlock = new BufferBlock<int>();

            // Post several messages to the block.
            for (int i = 0; i < 3; i++)
            {
                bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(bufferBlock.Receive());
            }

            /* Output:
               0
               1
               2
             */

            // Post more messages to the block.
            for (int i = 0; i < 3; i++)
            {
                bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            int value;
            while (bufferBlock.TryReceive(out value))
            {
                Console.WriteLine(value);
            }

            /* Output:
               0
               1
               2
             */

            // Write to and read from the message block concurrently.
            var post01 = Task.Run(() =>
            {
                bufferBlock.Post(0);
                bufferBlock.Post(1);
            });
            var receive = Task.Run(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(bufferBlock.Receive());
                }
            });
            var post2 = Task.Run(() =>
            {
                bufferBlock.Post(2);
            });
            Task.WaitAll(post01, receive, post2);

            /* Sample output:
               2
               0
               1
             */

            // Demonstrate asynchronous dataflow operations.
            AsyncSendReceive(bufferBlock).Wait();

        }
    }
}
