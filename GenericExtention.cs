/// <summary>
/// time:2019/5/9 23:46
/// author:Sun
/// des:Generic_静态类拓展
/// </summary>
public static class GenericExtention{
	
	/// <summary>
	/// 得到类型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static string GetTypeName<T>()
	{
		return typeof(T).ToString();
	}
	
}
