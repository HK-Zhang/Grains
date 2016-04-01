using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class ThreadSafeDicDemo
    {
        public void Execute()
        {
            Foo1();
            Foo2();
            Foo3();
            Foo4();
        }

        private void Foo1()
        {
            var concurentDictionary = new ConcurrentDictionary<int, int>();

            var w = new ManualResetEvent(false);
            int timedCalled = 0;
            var threads = new List<Thread>();
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(() =>
                {
                    w.WaitOne();
                    concurentDictionary.GetOrAdd(1, i1 =>
                    {
                        Interlocked.Increment(ref timedCalled);
                        return 1;
                    });
                }));
                threads.Last().Start();
            }

            w.Set();//release all threads to start at the same time         
            Thread.Sleep(100);
            Console.WriteLine(timedCalled);// output is 4, means call initial 4 times
            //Console.WriteLine(concurentDictionary.Keys.Count);

        }

        private void Foo2()
        {
            var concurentDictionary = new ConcurrentDictionary<int, int>();

            var w = new ManualResetEvent(false);
            int timedCalled = 0;
            var threads = new List<Thread>();
            Lazy<int> lazy = new Lazy<int>(() => { Interlocked.Increment(ref timedCalled); return 1; });
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(() =>
                {
                    w.WaitOne();
                    concurentDictionary.GetOrAdd(1, i1 =>
                    {
                        return lazy.Value;
                    });
                }));
                threads.Last().Start();
            }

            w.Set();//release all threads to start at the same time         
            Thread.Sleep(100);
            Console.WriteLine(timedCalled);// output is 1

        }

        private void Foo3()
        {
            var concurentDictionary = new Dictionary<int, int>();
            var rwLockSlim = new ReaderWriterLockSlim();

            var w = new ManualResetEvent(false);
            int timedCalled = 0;
            var threads = new List<Thread>();
            int j;
            Lazy<int> lazy = new Lazy<int>(() => { Interlocked.Increment(ref timedCalled); return 1; });
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(() =>
                {
                    w.WaitOne();
                    rwLockSlim.EnterUpgradeableReadLock();
                    try
                    {
                        if (!concurentDictionary.TryGetValue(1, out j))
                        {
                            rwLockSlim.EnterWriteLock();
                            try
                            {
                                Interlocked.Increment(ref timedCalled);
                                concurentDictionary[1] = 1;
                            }
                            finally
                            {
                                rwLockSlim.ExitWriteLock();
                            }
                        }
                    }
                    finally 
                    {
                        rwLockSlim.ExitUpgradeableReadLock();

                    }
                }));

                threads.Last().Start();
            }

            w.Set();//release all threads to start at the same time         
            Thread.Sleep(100);
            Console.WriteLine(timedCalled);// output is 1

        }

        private void Foo4()
        {
            var concurentDictionary = new Dictionary<int, int>();
            var rwLockSlim = new ReaderWriterLockSlim();

            var w = new ManualResetEvent(false);
            int timedCalled = 0;
            var threads = new List<Thread>();
            int j;
            Lazy<int> lazy = new Lazy<int>(() => { Interlocked.Increment(ref timedCalled); return 1; });
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                threads.Add(new Thread(() =>
                {
                    w.WaitOne();
                    bool exist = false;
                    rwLockSlim.EnterReadLock();
                    try 
                    {
                        exist = concurentDictionary.TryGetValue(1, out j);
                    }
                    finally 
                    {
                        rwLockSlim.ExitReadLock();
                    }

                    if (!exist)
                    {
                        rwLockSlim.EnterUpgradeableReadLock();
                        try
                        {
                            if (!concurentDictionary.TryGetValue(1, out j))
                            {
                                rwLockSlim.EnterWriteLock();
                                try
                                {
                                    Interlocked.Increment(ref timedCalled);
                                    concurentDictionary[1] = 1;
                                }
                                finally
                                {
                                    rwLockSlim.ExitWriteLock();
                                }
                            }
                        }
                        finally
                        {
                            rwLockSlim.ExitUpgradeableReadLock();

                        }
 
                    }


                }));

                threads.Last().Start();
            }

            w.Set();//release all threads to start at the same time         
            Thread.Sleep(100);
            Console.WriteLine(timedCalled);// output is 1

        }
    }
}
