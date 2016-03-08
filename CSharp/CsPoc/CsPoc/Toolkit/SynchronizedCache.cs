using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSDemo
{
    public class SynchronizedCache
    {


        public enum AddOrUpdateStatus
        {
            Added,
            Updated,
            Unchanged
        };

        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
        private Dictionary<int, string> innerCache = new Dictionary<int, string>();

        public string Read(int key)
        {
            //进入读锁，允许其他所有的读线程，写入线程被阻塞。
            cacheLock.EnterReadLock();
            try
            {
                return innerCache[key];
            }
            finally
            {
                cacheLock.ExitReadLock();
            }

        }

        public void Add(int key, string value)
        {
            //进入写锁，其他所有访问操作的线程都被阻塞。即写独占锁。
            cacheLock.EnterWriteLock();
            try
            {
                innerCache.Add(key, value);
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }


        public bool AddWithTimeout(int key, string value, int timeout)
        {
            //超时设置，如果在超时时间内，其他写锁还不释放，就放弃操作。
            if (cacheLock.TryEnterWriteLock(timeout))
            {
                try
                {
                    innerCache.Add(key, value);
                }
                finally
                {
                    cacheLock.ExitWriteLock();
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public AddOrUpdateStatus AddOrUpdate(int key, string value)
        {
            //进入升级锁。 同时只能有一个可升级锁线程。写锁，升级锁都被阻塞，但允许其他读取数据的线程。
            cacheLock.EnterUpgradeableReadLock();
            try
            {
                string result = null;
                if (innerCache.TryGetValue(key, out result))
                {
                    if (result == value)
                    {
                        return AddOrUpdateStatus.Unchanged;
                    }
                    else
                    {
                        //升级成写锁，其他所有线程都被阻塞。
                        cacheLock.EnterWriteLock();
                        try
                        {
                            innerCache[key] = value;
                        }
                        finally
                        {
                            //退出写锁，允许其他读线程。
                            cacheLock.ExitWriteLock();
                        }
                        return AddOrUpdateStatus.Updated;
                    }
                }
                else
                {
                    cacheLock.EnterWriteLock();
                    try
                    {
                        innerCache.Add(key, value);
                    }
                    finally
                    {
                        cacheLock.ExitWriteLock();
                    }
                    return AddOrUpdateStatus.Added;
                }
            }
            finally
            {
                //退出升级锁。
                cacheLock.ExitUpgradeableReadLock();
            }
        }


    }
}
