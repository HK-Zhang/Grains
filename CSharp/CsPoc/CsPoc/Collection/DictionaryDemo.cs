using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Collection
{
    public class DictionaryDemo
    {

    }


    public static class DectionaryHelper
    {
        public static T GetValue<T>(this IDictionary<object, object> self, string key)
        {
            var cnt = self.TryGetValue(key, out object val)
                ? (T)val
                : default(T);

            return cnt;
        }

        public static void SetValue<T>(this IDictionary<object, object> self, string key, T value)
        {
            if (self.ContainsKey(key))
            {
                self[key] = value;
            }
            else
            {
                self.Add(key, value);
            }
        }
    }

    //internal class CopyOnWriteDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    //{
    //    private readonly IDictionary<TKey, TValue> _sourceDictionary;
    //    private IDictionary<TKey, TValue> _innerDictionary;

    //    private IEqualityComparer<TKey> _comparer;
    //    public CopyOnWriteDictionary(IDictionary<TKey, TValue> sourceDictionary, IEqualityComparer<TKey> comparer)
    //    {
    //        _sourceDictionary = sourceDictionary;
    //        _comparer = comparer;
    //    }

    //    private IDictionary<TKey, TValue> ReadDictionary => _innerDictionary ?? _sourceDictionary;

    //    private IDictionary<TKey, TValue> WriteDictionary
    //    {
    //        get
    //        {
    //            if (_innerDictionary == null)
    //            {
    //                _innerDictionary = new Dictionary<TKey, TValue>(_sourceDictionary, _comparer);
    //            }
    //            return _innerDictionary;
    //        }
    //    }
    //}
}
