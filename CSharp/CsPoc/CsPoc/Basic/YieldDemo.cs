using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class YieldDemo
    {

        public void Execute()
        {
            Foo();
        }

        private void Foo()
        {
            IEnumerable<int> e = FromTo(1, 10);

            foreach (int x in e)
            {
                foreach (int y in e)
                {
                    Console.Write("{0,3} ", x * y);
                }
                Console.WriteLine();
            }


        }

        static IEnumerable<int> FromTo(int from, int to)
        {
            while (from <= to) yield return from++;
        }

    }

    class FromToTest
    {

    }


    class Stack<T> : IEnumerable<T>
    {
        T[] items;
        int count;

        public void Push(T item)
        {
            if (items == null)
            {
                items = new T[4];
            }
            else if (items.Length == count)
            {
                T[] newItems = new T[count * 2];
                Array.Copy(items, 0, newItems, 0, count);
                items = newItems;
            }
            items[count++] = item;
        }

        public T Pop()
        {
            T result = items[--count];
            items[count] = default(T);
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = count - 1; i >= 0; --i)
                yield return items[i];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = count - 1; i >= 0; --i)
                yield return items[i];
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    for (int i = count - 1; i >= 0; --i)
        //        yield return items[i];
        //}




    } 



}
