﻿using System;
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
}
