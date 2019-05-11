using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

/// <summary>
/// time:2019/5/11 10：31
/// author:Sun
/// des:String_静态类拓展
/// </summary>
public static class StringExtention{
	
    /// <summary>
    /// 检查字符串是Null或Empty
    /// </summary>
    /// <param name="selfStr"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string selfStr)
    {
        return string.IsNullOrEmpty(selfStr);
    }

    /// <summary>
    /// 检查字符串不是Null或Empty
    /// </summary>
    /// <param name="selfStr"></param>
    /// <returns></returns>
    public static bool IsNotNullAndEmpty(this string selfStr)
    {
        return !string.IsNullOrEmpty(selfStr);
    }
    
    /// <summary>
    /// Check Whether string trim is null or empty
    /// </summary>
    /// <param name="selfStr"></param>
    /// <returns></returns>
    public static bool IsTrimNotNullAndEmpty(this string selfStr)
    {
        return !string.IsNullOrEmpty(selfStr.Trim());
    }

    /// <summary>
    /// 避免每次都用.
    /// </summary>
    private static readonly char[] mCachedSplitCharArray = { '.' };

    /// <summary>
    /// 首字母大写
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string UppercaseFirst(this string str)
    {
        return char.ToUpper(str[0]) + str.Substring(1);
    }

    /// <summary>
    /// 首字母小写
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string LowercaseFirst(this string str)
    {
        return char.ToLower(str[0]) + str.Substring(1);
    }

    /// <summary>
    /// 回车转换行
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToUnixLineEndings(this string str)
    {
        return str.Replace("\r\n", "\n").Replace("\r", "\n");
    }

    /// <summary>
    /// 转CSV
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string ToCSV(this string[] values)
    {
        return string.Join(", ", values
            .Where(value => !string.IsNullOrEmpty(value))
            .Select(value => value.Trim())
            .ToArray()
        );
    }

    /// <summary>
    /// 数组转CSV
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string[] ArrayFromCSV(this string values)
    {
        return values
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(value => value.Trim())
            .ToArray();
    }

    public static string ToSpacedCamelCase(this string text)
    {
        var sb = new StringBuilder(text.Length * 2);
        sb.Append(char.ToUpper(text[0]));
        for (var i = 1; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]) && text[i - 1] != ' ')
            {
                sb.Append(' ');
            }

            sb.Append(text[i]);
        }

        return sb.ToString();
    }

    /// <summary>
    /// 有点不安全,编译器不会帮你排查错误。
    /// </summary>
    /// <param name="selfStr"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string FillFormat(this string selfStr, params object[] args)
    {
        return string.Format(selfStr, args);
    }

    /// <summary>
    /// 字符串拼接
    /// </summary>
    /// <param name="selfStr"></param>
    /// <param name="toAppend"></param>
    /// <returns></returns>
    public static StringBuilder Append(this string selfStr, string toAppend)
    {
        return new StringBuilder(selfStr).Append(toAppend);
    }

    /// <summary>
    /// 字符串反拼接
    /// </summary>
    /// <param name="selfStr"></param>
    /// <param name="toPrefix"></param>
    /// <returns></returns>
    public static string AddPrefix(this string selfStr, string toPrefix)
    {
        return new StringBuilder(toPrefix).Append(selfStr).ToString();
    }

    public static StringBuilder AppendFormat(this string selfStr, string toAppend, params object[] args)
    {
        return new StringBuilder(selfStr).AppendFormat(toAppend, args);
    }

    public static string LastWord(this string selfUrl)
    {
        return selfUrl.Split('/').Last();
    }

    /// <summary>
    /// ToInt
    /// </summary>
    /// <param name="selfStr"></param>
    /// <param name="defaulValue"></param>
    /// <returns></returns>
    public static int ToInt(this string selfStr, int defaulValue = 0)
    {
        var retValue = defaulValue;
        return int.TryParse(selfStr, out retValue) ? retValue : defaulValue;
    }

    /// <summary>
    /// ToDateTime
    /// </summary>
    /// <param name="selfStr"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static DateTime ToDateTime(this string selfStr, DateTime defaultValue = default(DateTime))
    {
        var retValue = defaultValue;
        return DateTime.TryParse(selfStr, out retValue) ? retValue : defaultValue;
    }


    /// <summary>
    /// ToFloat
    /// </summary>
    /// <param name="selfStr"></param>
    /// <param name="defaulValue"></param>
    /// <returns></returns>
    public static float ToFloat(this string selfStr, float defaulValue = 0)
    {
        var retValue = defaulValue;
        return float.TryParse(selfStr, out retValue) ? retValue : defaulValue;
    }

    /// <summary>
    /// 是否存在中文字符
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool HasChinese(this string input)
    {
        return Regex.IsMatch(input, @"[\u4e00-\u9fa5]");
    }

    /// <summary>
    /// 是否存在空格
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool HasSpace(this string input)
    {
        return input.Contains(" ");
    }

    /// <summary>
    /// 删除特定字符
    /// </summary>
    /// <param name="str"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static string RemoveString(this string str, params string[] targets)
    {
        return targets.Aggregate(str, (current, t) => current.Replace(t, string.Empty));
    }	
}
