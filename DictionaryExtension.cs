using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// time:2019/5/9 23:42
/// author:Sun
/// des:Dictionary_静态类拓展
/// </summary>
public static class DictionaryExtension{
    
    
    /// <summary>
    /// 遍历 Action<K, V> Key + Value
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dict"></param>
    /// <param name="action"></param>
    public static void ForEach<K, V>(this Dictionary<K, V> dict, Action<K, V> action)
    {
        var dictE = dict.GetEnumerator();

        while (dictE.MoveNext())
        {
            var current = dictE.Current;
            action(current.Key, current.Value);
        }

        dictE.Dispose();
    }

    /// <summary>
    /// 合并两个指定Dictionary
    /// </summary>
    /// <returns>The merge.</returns>
    /// <param name="dictionary">Dictionary.</param>
    /// <param name="dictionaries">Dictionaries.</param>
    /// <typeparam name="TKey">The 1st type parameter.</typeparam>
    /// <typeparam name="TValue">The 2nd type parameter.</typeparam>
    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
        params Dictionary<TKey, TValue>[] dictionaries)
    {
        return dictionaries.Aggregate(dictionary,
            (current, dict) => current.Union(dict).ToDictionary(kv => kv.Key, kv => kv.Value));
    }

  

    /// <summary>
    /// 向一个字典中添加另一个词典内容
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="dict"></param>
    /// <param name="addInDict"></param>
    /// <param name="isOverride"></param>
    public static void AddRange<K, V>(this Dictionary<K, V> dict, Dictionary<K, V> addInDict,
        bool isOverride = false)
    {
        var dictE = addInDict.GetEnumerator();

        while (dictE.MoveNext())
        {
            var current = dictE.Current;
            if (dict.ContainsKey(current.Key))
            {
                if (isOverride)
                    dict[current.Key] = current.Value;
                continue;
            }

            dict.Add(current.Key, current.Value);
        }

        dictE.Dispose();
    }
}
