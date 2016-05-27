using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryExtensions
{
    public static class DictionaryExtensionMethods
    {
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, TValue value, Action<TValue> updateAction)
        {
            if (dictionary.ContainsKey(key))
            {
                updateAction(dictionary[key]);
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public static IDictionary<TKey, TValue> SortByValueDescending<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary.OrderByDescending(entry => entry.Value)
                .ToDictionary(entry => entry.Key, entry => entry.Value);
        }
    }
}
