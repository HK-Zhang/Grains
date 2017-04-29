using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsPoc
{
    public class SpinLockDemo
    {
        int i = 0;
        List<int> li = new List<int>();
        SpinLock sl = new SpinLock();
        int signal = 0;

        public void Execute() 
        {
            foo1();
            //li.ForEach((t) => { Console.WriteLine(t); });
            Console.WriteLine("Li Count - Spinlock: "+li.Count);
            li.Clear();
            foo4();
            Console.WriteLine("Li Count - Nolock: " + li.Count);
            li.Clear();
            foo5();
            Console.WriteLine("Li Count - Customized Spinlock: " + li.Count);

        }

        public void foo1()
        {
            Parallel.For(0, 10000, r =>
            {
                bool gotLock = false;     //释放成功
                try
                {
                    sl.Enter(ref gotLock);    //进入锁
                    //Thread.Sleep(100);
                    if (i == 0)
                    {
                        i = 1;
                        li.Add(r);
                        i = 0;
                    }
                }
                finally
                {
                    if (gotLock) sl.Exit();  //释放
                }

            });
        }

        public void foo4()
        {
            Parallel.For(0, 10000, r =>
            {
                if (i == 0)
                {
                    i = 1;
                    li.Add(r);
                    i = 0;
                }
            });
        }

        public void foo5()
        {
            Parallel.For(0, 10000, r =>
            {
                while (Interlocked.Exchange(ref signal, 1) != 0)//加自旋锁
                {}
                li.Add(r);
                Interlocked.Exchange(ref signal, 0);  //释放锁
            });

        }

        public void foo6()
        {
            //Console.WriteLine(i);
            //Task.Run(new Action(foo2)).ContinueWith(new Action<Task>(t =>
            //{
            //    Console.WriteLine("foo2 completed: " + i);
            //}));
            //Console.WriteLine(i);
            //Task.Run(new Action(foo2)).ContinueWith(new Action<Task>(t =>
            //{
            //    Console.WriteLine("foo3 completed: " + i);
            //}));
            //Console.WriteLine(i);
        }
        public void foo2()
        {
            bool lck = false;
            sl.Enter(ref lck);
            Thread.Sleep(100);
            ++i;
            if (lck) sl.Exit(); 
        }

        public void foo3()
        {
            bool lck = false;
            sl.Enter(ref lck);
            ++i;
            if (lck) sl.Exit();
        }
    }
}
