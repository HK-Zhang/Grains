using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc.ThreadDemos
{
    public class ThreadUniqueID
    {
        public void Execute() 
        {

            int maxThreadNum, portThreadNum;

            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
            ThreadPool.SetMinThreads(250, portThreadNum);
            ThreadPool.SetMaxThreads(250, portThreadNum);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            ParallelLoopResult pr=Foo();

            while (!pr.IsCompleted)
            {
                
            }
            stopWatch.Stop();

            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            
        }

        public ParallelLoopResult Foo()
        {
            return System.Threading.Tasks.Parallel.For(0, 1000001, (i) =>
            {
                var slot = Thread.GetNamedDataSlot("UID");
                if (slot == null)
                {
                    Thread.AllocateNamedDataSlot("UID");
                }

                if (Thread.GetData(slot) == null)
                {
                    SID sid;
                    sid.dt=DateTime.Now;
                    sid.id=1;
                    Thread.SetData(slot,sid);
                }

                SID idStruct= (SID)Thread.GetData(slot);

                int id = idStruct.id;
                DateTime n = idStruct.dt;


                if (i == 1000000)
                    Console.WriteLine("{0},{1},{2}{3}{4}{5}{6}{7}{8}", Thread.CurrentThread.ManagedThreadId, id, n.Year, n.Month, n.Day, n.Hour, n.Minute, n.Second, n.Millisecond);

                if (n != DateTime.Now)
                {
                    idStruct.dt = DateTime.Now;
                    idStruct.id = 1;
                    Thread.SetData(slot, idStruct);
                }
                else
                {
                    idStruct.id++;
                    Thread.SetData(slot, idStruct);
                }
            });

        }
    }

    struct SID 
    {
        public DateTime dt;
        public int id;
    }
}
