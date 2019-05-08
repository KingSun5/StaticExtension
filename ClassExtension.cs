/// <summary>
/// time:2019/5/8
/// author:Sun
/// des:Class_静态类拓展
/// </summary>
public static class ClassExtension{

	/// <summary>
	/// 判断类是空
	/// </summary>
	/// <param name="selfObj"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static bool IsNull<T>(this T selfObj) where T : class
	{
		return null == selfObj;
	}

	/// <summary>
	/// 判断类不是空
	/// </summary>
	/// <param name="selfObj"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static bool IsNotNull<T>(this T selfObj) where T : class
	{
		return null != selfObj;
	}
}
