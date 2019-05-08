using System;

/// <summary>
/// time:2019/5/9 23:29
/// author:Sun
/// des:FuncOrActionOrEvent_静态类拓展
/// </summary>
public static class FuncOrActionOrEventExtension{

	
	#region Func Extension

	/// <summary>
	/// Func是否空，非空执行
	/// </summary>
	/// <param name="selfFunc"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static T InvokeGracefully<T>(this Func<T> selfFunc)
	{
		return null != selfFunc ? selfFunc() : default(T);
	}

	#endregion

	#region Action

	/// <summary>
	/// Action是否空，非空执行
	/// </summary>
	/// <param name="selfAction"></param>
	/// <returns> call succeed</returns>
	public static bool InvokeGracefully(this System.Action selfAction)
	{
		if (null != selfAction)
		{
			selfAction();
			return true;
		}
		return false;
	}

	/// <summary>
	/// Action<T>是否空，非空执行
	/// </summary>
	/// <param name="selfAction"></param>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static bool InvokeGracefully<T>(this Action<T> selfAction, T t)
	{
		if (null != selfAction)
		{
			selfAction(t);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Action<T, K>是否空，非空执行
	/// </summary>
	/// <param name="selfAction"></param>
	/// <returns> call succeed</returns>
	public static bool InvokeGracefully<T, K>(this Action<T, K> selfAction, T t, K k)
	{
		if (null != selfAction)
		{
			selfAction(t, k);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Delegate是否空，非空执行
	/// </summary>
	/// <param name="selfAction"></param>
	/// <returns> call suceed </returns>
	public static bool InvokeGracefully(this Delegate selfAction, params object[] args)
	{
		if (null != selfAction)
		{
			selfAction.DynamicInvoke(args);
			return true;
		}
		return false;
	}

	#endregion
}
