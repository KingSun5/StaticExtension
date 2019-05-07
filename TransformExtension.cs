
using UnityEngine;

/// <summary>
/// time:2019/5/8
/// author:Sun
/// des:Transfom_静态类拓展
/// </summary>
public static class TransformExtension{
    
    /// <summary>
    /// 设置X
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="x"></param>
    public static void SetX(this Transform transform, float x)  
    {  
        Vector3 newPosition =   
            new Vector3(x, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
 
    /// <summary>
    /// 设置Y
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="y"></param>
    public static void SetY(this Transform transform, float y)  
    {  
        Vector3 newPosition = 
            new Vector3 (transform.position.x, y, transform.position.z);
        transform.position = newPosition;
    }
 
    /// <summary>
    /// 设置Z
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="z"></param>
    public static void SetZ(this Transform transform, float z)  
    {  
        Vector3 newPosition = 
            new Vector3 (transform.position.x, transform.position.y, z);
        transform.position = newPosition;
    }
 
    /// <summary>
    /// 获取X
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static float GetX(this Transform transform)  
    {  
        return transform.position.x;  
    }
	
    /// <summary>
    ///  获取Y
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static float GetY(this Transform transform)  
    {  
        return transform.position.y;  
    }
	
    /// <summary>
    /// 获取Z
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static float GetZ(this Transform transform)  
    {  
        return transform.position.z;  
    } 
}
