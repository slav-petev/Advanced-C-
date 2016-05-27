using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryExtensions
{
    public static class DictionaryExtensionMethods
    {
        /// <summary>
        /// Adds a new entry to the dictionary. If it's present,
        /// updates the current entry
        /// </summary>
        /// <typeparam name="TKey">The type of the key</typeparam>
        /// <typeparam name="TValue">The type of the value</typeparam>
        /// <param name="dictionary">The dictionary we are operating on</param>
        /// <param name="key">The key for which the value is stored</param>
        /// <param name="value">The value to be added, in case it does not exist</param>
        /// <param name="updateAction">An action to be performed on the existing element</param>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, TValue value, Action updateAction)
        {
            if (dictionary.ContainsKey(key))
            {
                updateAction();
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
