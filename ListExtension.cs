using System;
using Boo.Lang;

/// <summary>
/// time:2019/5/9 23:42
/// author:Sun
/// des:List_静态类拓展
/// </summary>
public static class ListExtension{
    
        /// <summary>
        /// 遍历List action参数反顺序输出 
        /// </summary>
        /// <returns>The each reverse.</returns>
        /// <param name="selfList">Self list.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static List<T> ForEachReverse<T>(this List<T> selfList, Action<T> action)
        {
            if (action == null) throw new ArgumentException();

            for (var i = selfList.Count - 1; i >= 0; --i)
                action(selfList[i]);

            return selfList;
        }

        /// <summary>
        /// 遍历List action参数反顺序  输出 + 下标
        /// </summary>
        /// <returns>The each reverse.</returns>
        /// <param name="selfList">Self list.</param>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static List<T> ForEachReverse<T>(this List<T> selfList, Action<T, int> action)
        {
            if (action == null) throw new ArgumentException();

            for (var i = selfList.Count - 1; i >= 0; --i)
                action(selfList[i], i);

            return selfList;
        }

        /// <summary>
        /// 遍历列表 Action<int, T>参数输出 下标 + 目标
        /// </summary>
        /// <typeparam name="T">列表类型</typeparam>
        /// <param name="list">目标表</param>
        /// <param name="action">行为</param>
        public static void ForEach<T>(this List<T> list, Action<int, T> action)
        {
            for (var i = 0; i < list.Count; i++)
            {
                action(i, list[i]);
            }
        }

        /// <summary>
        /// 拷贝到
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        public static void CopyTo<T>(this List<T> from, List<T> to, int begin = 0, int end = -1)
        {
            if (begin < 0)
            {
                begin = 0;
            }

            var endIndex = Math.Min(from.Count, to.Count) - 1;

            if (end != -1 && end < endIndex)
            {
                endIndex = end;
            }

            for (var i = begin; i < end; i++)
            {
                to[i] = from[i];
            }
        }

        /// <summary>
        /// 将List转为Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selfList"></param>
        /// <returns></returns>
        public static T[] ToArraySavely<T>(this List<T> selfList)
        {
            var res = new T[selfList.Count];

            for (var i = 0; i < selfList.Count; i++)
            {
                res[i] = selfList[i];
            }

            return res;
        }

        /// <summary>
        /// 获取，如果没有该数则返回null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selfList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static T TryGet<T>(this List<T> selfList, int index)
        {
            return selfList.Count > index ? selfList[index] : default(T);
        }
    
}
