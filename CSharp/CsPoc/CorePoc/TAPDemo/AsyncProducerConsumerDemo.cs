using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CorePoc.TAPDemo
{
    class AsyncProducerConsumerDemo
    {
        private static AsyncProducerConsumerCollection<int> m_data = new AsyncProducerConsumerCollection<int>();

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
                int nextItem = await m_data.Take();
                ProcessNextItem(nextItem);
            }
        }

        private static void ProcessNextItem(int item)
        {
            Console.WriteLine(item);
        }

        private static void Produce(int data)
        {
            m_data.Add(data);
        }
    }

    public class AsyncProducerConsumerCollection<T>
    {
        private readonly Queue<T> m_collection = new Queue<T>();
        private readonly Queue<TaskCompletionSource<T>> m_waiting =
            new Queue<TaskCompletionSource<T>>();

        public void Add(T item)
        {
            TaskCompletionSource<T> tcs = null;
            lock (m_collection)
            {
                if (m_waiting.Count > 0) tcs = m_waiting.Dequeue();
                else m_collection.Enqueue(item);
            }
            if (tcs != null) tcs.TrySetResult(item);
        }

        public Task<T> Take()
        {
            lock (m_collection)
            {
                if (m_collection.Count > 0)
                {
                    return Task.FromResult(m_collection.Dequeue());
                }
                else
                {
                    var tcs = new TaskCompletionSource<T>();
                    m_waiting.Enqueue(tcs);
                    return tcs.Task;
                }
            }
        }
    }
}
