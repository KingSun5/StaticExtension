using System;
using System.Collections;
using System.Reflection;

/// <summary>
/// time:2019/5/10 0:43
/// author:Sun
/// des:OOP_静态类拓展
/// </summary>
public static class OOPExtension{
	
	   /// <summary>
        /// Determines whether the type implements the specified interface
        /// and is not an interface itself.
        /// </summary>
        /// <returns><c>true</c>, if interface was implementsed, <c>false</c> otherwise.</returns>
        /// <param name="type">Type.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool ImplementsInterface<T>(this Type type)
        {
            return !type.IsInterface && ((IList) type.GetInterfaces()).Contains(typeof(T));
        }

        /// <summary>
        /// Determines whether the type implements the specified interface
        /// and is not an interface itself.
        /// </summary>
        /// <returns><c>true</c>, if interface was implementsed, <c>false</c> otherwise.</returns>
        /// <param name="type">Type.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static bool ImplementsInterface<T>(this object obj)
        {
            var type = obj.GetType();
            return !type.IsInterface && ((IList) type.GetInterfaces()).Contains(typeof(T));
        }
    }

    public class AssemblyManager
    {
        /// <summary>
        /// 编辑器默认的程序集Assembly-CSharp.dll
        /// </summary>
        private static Assembly defaultCSharpAssembly;

#if UNITY_ANDROID
        /// <summary>
        /// 程序集缓存
        /// </summary>
        private static Dictionary<string, Assembly> assemblyCache = new Dictionary<string, Assembly>();
#endif

        /// <summary>
        /// 获取编辑器默认的程序集Assembly-CSharp.dll
        /// </summary>
        public static Assembly DefaultCSharpAssembly
        {
            get
            {
                //如果已经找到，直接返回
                if (defaultCSharpAssembly != null)
                    return defaultCSharpAssembly;

                //从当前加载的程序包中寻找，如果找到，则直接记录并返回
                var assems = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assem in assems)
                {
                    //所有本地代码都编译到Assembly-CSharp中
                    if (assem.GetName().Name == "Assembly-CSharp")
                    {
                        //保存到列表并返回
                        defaultCSharpAssembly = assem;
                        break;
                    }
                }

                return defaultCSharpAssembly;
            }
        }

        /// <summary>
        /// 获取Assembly
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Assembly GetAssembly(string name)
        {
#if UNITY_ANDROID
            if (!assemblyCache.ContainsKey(name))
                return null;

            return assemblyCache[name];
#else
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {

                if (assembly.GetName().Name == name)
                {
                    return assembly;
                }
            }

            return null;
#endif
        }



        /// <summary>
        /// 获取默认的程序集
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type GetDefaultAssemblyType(string typeName)
        {
            return DefaultCSharpAssembly.GetType(typeName);
        }


        public static Type[] GetTypeList(string assemblyName)
        {
            return GetAssembly(assemblyName).GetTypes();
        }
	
}
