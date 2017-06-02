using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemo
{
    class LockDemo
    {
        static int count = 1;

        public static void RunDemo()
        {
            //InterLockDemo();
            //ReadWriteLockDemo();
            //InterLockComoare();
            ParallelDe();
        }

        static void ParallelDe()
        {
            Parallel.For(0,5,(i)=> {
                try
                {
                    throw new Exception("abc");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine(i);
                }
            });
        }

        static void InterLockComoare()
        {
            int taskCount = 0;

            Interlocked.Increment(ref taskCount);
            Interlocked.Increment(ref taskCount);


            int c = Interlocked.CompareExchange(ref taskCount, 2, 2);
            Console.WriteLine(c);

            Interlocked.Decrement(ref taskCount);
            c = Interlocked.CompareExchange(ref taskCount, 2, 3);
            Console.WriteLine(c);
        }

        static void InterLockDemo()
        {
            Thread t1 = new Thread(new ThreadStart(F1));
            Thread t2 = new Thread(new ThreadStart(F2));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

        }

        static void ReadWriteLockDemo()
        {
            List<string> list = new List<string>(1000);
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add("Character:" + i);
            }

            MyQueue mq = new MyQueue(list);

            string last = list[list.Count - 1];

            for (int i = 0; i < list.Capacity; i++)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    Console.WriteLine(mq.LootFirst());
                });
            }

            while (mq.Count > 0)
            {
                foreach (var item in mq)
                {
                    if (item == last)
                    {
                        Console.WriteLine("Still there");
                    }
                }
            }
        }


        static void F1()
        {
            for (int i = 0; i < 5; ++i)
            {
                Interlocked.Increment(ref count);
                System.Console.WriteLine("Counter++ {0}", count);
                Thread.Sleep(100);

            }
        }

        static void F2()
        {
            for (int i = 0; i < 5; ++i)
            {
                Interlocked.Decrement(ref count);
                System.Console.WriteLine("Counter-- {0}", count);
                Thread.Sleep(100);

            }

            Interlocked.CompareExchange(ref count, 5, 1);
            System.Console.WriteLine("CompareExchange {0}", count);
        }

        
    }

    public class UsingLock<T> 
    {
        public bool Enabled { get; set; }

        private struct Lock : IDisposable {

            private ReaderWriterLockSlim _lock;
            private bool _IsWrite;

            public Lock(ReaderWriterLockSlim rwl, bool isWrite)
            {
                _lock = rwl;
                _IsWrite = isWrite;
            }

            public void Dispose()
            {
                if (_IsWrite)
                {
                    if (_lock.IsWriteLockHeld)
                    {
                        _lock.ExitWriteLock();
                    }
                }
                else 
                {
                    if (_lock.IsReadLockHeld)
                    {
                        _lock.ExitReadLock();
                    }
                }
            }
        }

        private class Disposable : IDisposable
        {

            public static readonly Disposable Empty = new Disposable();

            public void Dispose() { }
        }

        private ReaderWriterLockSlim _LockSlim = new ReaderWriterLockSlim();
        private T _Data;

        public UsingLock()
        {
            Enabled = true;
        }

        public UsingLock(T data)
        {
            Enabled = true;
            _Data = data;
        }

        public T Data
        {
            get
            {
                if (_LockSlim.IsReadLockHeld || _LockSlim.IsWriteLockHeld)
                {
                    return _Data;
                }
                throw new MemberAccessException("请先进入读取或写入锁定模式再进行操作");
            }
            set
            {
                if (_LockSlim.IsWriteLockHeld == false)
                {
                    throw new MemberAccessException("只有写入模式中才能改变Data的值");
                }
                _Data = value;
            }
        }

        public IDisposable Read()
        {
            if (Enabled == false || _LockSlim.IsReadLockHeld || _LockSlim.IsWriteLockHeld)
            {
                return Disposable.Empty;
            }
            else
            {
                _LockSlim.EnterReadLock();
                return new Lock(_LockSlim, false);
            }
        }

        public IDisposable Write()
        {
            if (Enabled == false || _LockSlim.IsWriteLockHeld)
            {
                return Disposable.Empty;
            }
            else if (_LockSlim.IsReadLockHeld)
            {
                throw new NotImplementedException("读取模式下不能进入写入锁定状态");
            }
            else
            {
                _LockSlim.EnterWriteLock();
                return new Lock(_LockSlim, true);
            }
        }

    }


    class MyQueue:IEnumerable<string>
    {
        List<string> _List;
        UsingLock<object> _Lock;

        public MyQueue(IEnumerable<string> strings)
        {
            _List = new List<string>(strings);
            _Lock = new UsingLock<object>();
        }

        public string LootFirst()
        {
            using (_Lock.Write())
            {
                if (_List.Count == 0)
                {
                    _Lock.Enabled = false;
                    return null;
                }
                var s = _List[0];
                _List.RemoveAt(0);
                return s;
            }
        }

        public int Count { get { return _List.Count; } }

        public IEnumerator<string> GetEnumerator()
        {
            using (_Lock.Read())
            {
                foreach (var item in _List)
                {
                    yield return item;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
