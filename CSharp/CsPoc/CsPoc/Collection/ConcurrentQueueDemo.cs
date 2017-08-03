using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class ConcurrentQueueDemo
    {
        public static ConcurrentQueue<CQDT> queue = new ConcurrentQueue<CQDT>();

        public IEnumerable<CQDT> Dequeue()
        {
            CQDT s;
            List<CQDT> lst = new List<CQDT>();

            do
            {
                if (queue.TryDequeue(out s))
                {
                    lst.Add(s);
                }
                else
                {
                    return lst;
                }
            } while (true);

        }

    }

    public class CQDT
    {
        public string Id { get; set; }
    }
}
