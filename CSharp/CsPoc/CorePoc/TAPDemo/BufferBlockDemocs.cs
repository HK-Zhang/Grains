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
    }
}
