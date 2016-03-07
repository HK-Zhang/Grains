using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class LinqDistinctDemo
    {
        List<Box> products = new List<Box>()
            {
                new Box(){ Id="1", Name="n1"},
                new Box(){ Id="1", Name="n2"},
                new Box(){ Id="2", Name="n1"},
                new Box(){ Id="2", Name="n2"},
            };

        public void Execute() 
        {
            //Foo1();
            //Foo2();
            //Foo3();
            //Foo4();
            Foo5();
        }


        public void Foo1()
        {
            var distinctProduct = products.Distinct();
            distinctProduct.ToList().ForEach((p)=>Console.WriteLine(p.Name));
        }

        public void Foo2()
        {
            var distinctProduct = products.Distinct(new BoxIdComparer());
            distinctProduct.ToList().ForEach((p) => Console.WriteLine(p.Name));
        }

        public void Foo3()
        {
            var distinctProduct = products.Distinct(new PropertyComparer<Box>("Name"));
            distinctProduct.ToList().ForEach((p) => Console.WriteLine(p.Name));
        }

        public void Foo4()
        {
            var distinctProduct = products.Distinct(new FastPropertyComparer<Box>("Name"));
            distinctProduct.ToList().ForEach((p) => Console.WriteLine(p.Name));
        }

        public void Foo5()
        {
            var distinctProduct = products.Distinct(p => p.Id);
            distinctProduct.ToList().ForEach((p) => Console.WriteLine(p.Name));
        }
    }

    public class BoxIdComparer : IEqualityComparer<Box>
    {
        public bool Equals(Box x, Box y)
        {
            if (x == null)
                return y == null;
            return x.Id == y.Id;
        }

        public int GetHashCode(Box obj)
        {
            if (obj == null)
                return 0;
            return obj.Id.GetHashCode();
        }
    }

    public class PropertyComparer<T> : IEqualityComparer<T>
    {
        private PropertyInfo _PropertyInfo;

        /// <summary>
        /// 通过propertyName 获取PropertyInfo对象    
        /// </summary>
        /// <param name="propertyName"></param>
        public PropertyComparer(string propertyName)
        {
            _PropertyInfo = typeof(T).GetProperty(propertyName,
            BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (_PropertyInfo == null)
            {
                throw new ArgumentException(string.Format("{0} is not a property of type {1}.",
                    propertyName, typeof(T)));
            }
        }

        #region IEqualityComparer<T> Members

        public bool Equals(T x, T y)
        {
            object xValue = _PropertyInfo.GetValue(x, null);
            object yValue = _PropertyInfo.GetValue(y, null);

            if (xValue == null)
                return yValue == null;

            return xValue.Equals(yValue);
        }

        public int GetHashCode(T obj)
        {
            object propertyValue = _PropertyInfo.GetValue(obj, null);

            if (propertyValue == null)
                return 0;
            else
                return propertyValue.GetHashCode();
        }

        #endregion
    }

    public class FastPropertyComparer<T> : IEqualityComparer<T>
    {
        private Func<T, Object> getPropertyValueFunc = null;

        /// <summary>
        /// 通过propertyName 获取PropertyInfo对象
        /// </summary>
        /// <param name="propertyName"></param>
        public FastPropertyComparer(string propertyName)
        {
            PropertyInfo _PropertyInfo = typeof(T).GetProperty(propertyName,
            BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (_PropertyInfo == null)
            {
                throw new ArgumentException(string.Format("{0} is not a property of type {1}.",
                    propertyName, typeof(T)));
            }

            ParameterExpression expPara = Expression.Parameter(typeof(T), "obj");
            MemberExpression me = Expression.Property(expPara, _PropertyInfo);
            getPropertyValueFunc = Expression.Lambda<Func<T, object>>(me, expPara).Compile();
        }

        #region IEqualityComparer<T> Members

        public bool Equals(T x, T y)
        {
            object xValue = getPropertyValueFunc(x);
            object yValue = getPropertyValueFunc(y);

            if (xValue == null)
                return yValue == null;

            return xValue.Equals(yValue);
        }

        public int GetHashCode(T obj)
        {
            object propertyValue = getPropertyValueFunc(obj);

            if (propertyValue == null)
                return 0;
            else
                return propertyValue.GetHashCode();
        }

        #endregion
    }




    public class Box
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


    public class CommonEqualityComparer<T, V> : IEqualityComparer<T>
    {
        private Func<T, V> keySelector;
        private IEqualityComparer<V> comparer;

        public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public CommonEqualityComparer(Func<T, V> keySelector)
            : this(keySelector, EqualityComparer<V>.Default)
        { }

        public bool Equals(T x, T y)
        {
            return comparer.Equals(keySelector(x), keySelector(y));
        }

        public int GetHashCode(T obj)
        {
            return comparer.GetHashCode(keySelector(obj));
        }
    }

    public static class DistinctExtensions
    {
        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector)
        {
            return source.Distinct(new CommonEqualityComparer<T, V>(keySelector));
        }

        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            return source.Distinct(new CommonEqualityComparer<T, V>(keySelector, comparer));
        }

    }
}
