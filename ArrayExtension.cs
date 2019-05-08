using System;

/// <summary>
/// time:2019/5/9 23:42
/// author:Sun
/// des:Array_静态类拓展
/// </summary>
public static class ArrayExtension{

    /// <summary>
    /// 遍历Array action参数输出
    /// </summary>
    /// <returns>The each.</returns>
    /// <param name="selfArray">Self array.</param>
    /// <param name="action">Action.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public static T[] ForEach<T>(this T[] selfArray, Action<T> action)
    {
        Array.ForEach(selfArray, action);
        return selfArray;
    }
}
