using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// 获取与指定的键相关联的值，如果没有则返回输入的默认值
        /// </summary>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }

        /// <summary>
        /// 向字典中批量添加键值对
        /// </summary>
        /// <param name="replaceExisted">如果已存在，是否替换</param>
        public static Dictionary<TKey, TValue> AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> values, bool replaceExisted)
        {
            foreach (var item in values)
            {
                if (dict.ContainsKey(item.Key) == false || replaceExisted)
                    dict[item.Key] = item.Value;
            }
            return dict;
        }
    }

    public static class WhereIfExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
    }

    public static class IsBetweenExtension
    {
        public static bool IsBetween<T>(this T t, T lowerBound, T upperBound,bool includeLowerBound = false, bool includeUpperBound = false)
        where T : IComparable<T>
        {
            if (t == null) throw new ArgumentNullException("t");

            var lowerCompareResult = t.CompareTo(lowerBound);
            var upperCompareResult = t.CompareTo(upperBound);

            return (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        public static bool IsBetween<T>(this T t, T lowerBound, T upperBound, IComparer<T> comparer, bool includeLowerBound = false, bool includeUpperBound = false)
        {
            if (comparer == null) throw new ArgumentNullException("comparer");

            var lowerCompareResult = comparer.Compare(t, lowerBound);
            var upperCompareResult = comparer.Compare(t, upperBound);

            return (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }
    }

    public class PersonBirthdayComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return Comparer<DateTime>.Default.Compare(x.Birthday, y.Birthday);
        }
    }


    public class DictionaryExtensionDemo
    {
        public static void Execute()
        {
            Foo1();
        }

        public static void Foo1()
        {
            var dict = new Dictionary<int, string>();
            var dict2 = new Dictionary<int, string>();
            dict[2] = "b";
            dict[3] = "c";

            dict2.AddRange(dict, false);

            Console.WriteLine(dict2.GetValue(2));
            Console.WriteLine(dict2.GetValue(4, "d"));
        }

        public static void Foo2()
        {
            //int
            bool b0 = 3.IsBetween(1, 5);
            bool b1 = 3.IsBetween(1, 3, includeUpperBound: true);
            bool b2 = 3.IsBetween(3, 5, includeLowerBound: true);
            //double
            bool b3 = 3.14.IsBetween(3.0, 4.0);
            //string
            bool b4 = "ND".IsBetween("NA", "NC");
            //DateTime
            bool b5 = new DateTime(2011, 2, 17).IsBetween(new DateTime(2011, 1, 1), new DateTime(2011, 3, 1));

            var p1 = new Person { Name = "Henry", Birthday = new DateTime(1990, 1, 1) };
            var p2 = new Person { Name = "Jim", Birthday = new DateTime(2000, 1, 1) };
            var p3 = new Person { Name = "mark", Birthday = new DateTime(2010, 1, 1) };
            bool b6 = p2.IsBetween(p1, p3, new PersonBirthdayComparer());
        }

        public IQueryable<Person> Query(IQueryable<Person> source, string name, string code, string address)
        {
            return source
                .WhereIf(p => p.Name.Contains(name), string.IsNullOrEmpty(name) == false)
                .WhereIf(p => p.Code.Contains(code), string.IsNullOrEmpty(code) == false)
                .WhereIf(p => p.Code.Contains(address), string.IsNullOrEmpty(address) == false);
        }
    }


}
