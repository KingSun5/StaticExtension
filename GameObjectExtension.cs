using UnityEngine;

/// <summary>
/// time:2019/5/10 0:43
/// author:Sun
/// des:GameObject_静态类拓展
/// </summary>
public static class GameObjectExtention{
	
	/// <summary>
	/// GameObject是否空
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public static bool IsNullToInit(this GameObject obj)  
	{
		if (obj==null)
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// GameObject设置Name
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="name"></param>
	public static void SetName(this GameObject obj, string name)
	{
		if (obj==null)
		{
			Debug.LogError("Error:obj is null！");
			return;
		}

		if (name==null)
		{
			name = "obj";
		}
		obj.name = name;
	}

	/// <summary>
	/// 实例化
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	public static GameObject InitSelf(this GameObject obj)
	{
		obj = new GameObject();
		return obj;
	}
	
	/// <summary>
	/// 实例化并设置Name
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	public static GameObject InitSelf(this GameObject obj,string name)
	{
		obj = new GameObject();
		obj.SetName(name);
		return obj;
	}
}
