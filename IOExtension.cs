using System.IO;
using System.Linq;
using Boo.Lang;
using System.Collections.Generic;


/// <summary>
/// time:2019/5/10 0:56
/// author:Sun
/// des:IO_静态类拓展
/// </summary>
public static class IOExtension{
	
	   /// <summary>
        /// 创建新的文件夹,如果存在则不创建
        /// </summary>
        public static string CreateDirIfNotExists(this string dirFullPath)
        {
            if (!Directory.Exists(dirFullPath))
            {
                Directory.CreateDirectory(dirFullPath);
            }

            return dirFullPath;
        }

        /// <summary>
        /// 删除文件夹，如果存在
        /// </summary>
        public static void DeleteDirIfExists(this string dirFullPath)
        {
            if (Directory.Exists(dirFullPath))
            {
                Directory.Delete(dirFullPath, true);
            }
        }

        /// <summary>
        /// 清空 Dir,如果存在。
        /// </summary>
        public static void EmptyDirIfExists(this string dirFullPath)
        {
            if (Directory.Exists(dirFullPath))
            {
                Directory.Delete(dirFullPath, true);
            }

            Directory.CreateDirectory(dirFullPath);
        }

        /// <summary>
        /// 删除文件 如果存在
        /// </summary>
        /// <param name="fileFullPath"></param>
        /// <returns> True if exists</returns>
        public static bool DeleteFileIfExists(this string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
                return true;
            }

            return false;
        }

        public static string CombinePath(this string selfPath, string toCombinePath)
        {
            return Path.Combine(selfPath, toCombinePath);
        }

        #region 未经过测试

        /// <summary>
        /// 保存文本
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        public static void SaveText(this string text, string path)
        {
            path.DeleteFileIfExists();

            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (var sr = new StreamWriter(fs))
                {
                    sr.Write(text); //开始写入值
                }
            }
        }


        /// <summary>
        /// 读取文本
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ReadText(this FileInfo file)
        {
            return ReadText(file.FullName);
        }

        /// <summary>
        /// 读取文本
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ReadText(this string fileFullPath)
        {
            var result = string.Empty;

            using (var fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

#if UNITY_EDITOR
        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="path"></param>
        public static void OpenFolder(string path)
        {
#if UNITY_STANDALONE_OSX
            System.Diagnostics.Process.Start("open", path);
#elif UNITY_STANDALONE_WIN
            System.Diagnostics.Process.Start("explorer.exe", path);
#endif
        }
#endif

        /// <summary>
        /// 获取文件夹名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string fileName)
        {
            fileName = IOExtension.MakePathStandard(fileName);
            return fileName.Substring(0, fileName.LastIndexOf('/'));
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="path"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string GetFileName(string path, char separator = '/')
        {
            path = IOExtension.MakePathStandard(path);
            return path.Substring(path.LastIndexOf(separator) + 1);
        }

        /// <summary>
        /// 获取不带后缀的文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string GetFileNameWithoutExtention(string fileName, char separator = '/')
        {
            return GetFilePathWithoutExtention(GetFileName(fileName, separator));
        }

        /// <summary>
        /// 获取不带后缀的文件路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFilePathWithoutExtention(string fileName)
        {
            if (fileName.Contains("."))
                return fileName.Substring(0, fileName.LastIndexOf('.'));
            return fileName;
        }

        /// <summary>
        /// 使目录存在,Path可以是目录名必须是文件名
        /// </summary>
        /// <param name="path"></param>
        public static void MakeFileDirectoryExist(string path)
        {
            string root = Path.GetDirectoryName(path);
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        /// <summary>
        /// 使目录存在
        /// </summary>
        /// <param name="path"></param>
        public static void MakeDirectoryExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 结合目录
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string Combine(params string[] paths)
        {
            string result = "";
            foreach (string path in paths)
            {
                result = Path.Combine(result, path);
            }

            result = MakePathStandard(result);
            return result;
        }

        /// <summary>
        /// 获取父文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetPathParentFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            return Path.GetDirectoryName(path);
        }


        /// <summary>
        /// 使路径标准化，去除空格并将所有'\'转换为'/'
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string MakePathStandard(string path)
        {
            return path.Trim().Replace("\\", "/");
        }

        public static Boo.Lang.List<string> GetDirSubFilePathList(this string dirABSPath, bool isRecursive = true, string suffix = "")
        {
            var pathList = new Boo.Lang.List<string>();
            var di = new DirectoryInfo(dirABSPath);

            if (!di.Exists)
            {
                return pathList;
            }

            var files = di.GetFiles();
            foreach (var fi in files)
            {
                if (!string.IsNullOrEmpty(suffix))
                {
                    if (!fi.FullName.EndsWith(suffix, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                }

                pathList.Add(fi.FullName);
            }

            if (isRecursive)
            {
                var dirs = di.GetDirectories();
                foreach (var d in dirs)
                {
                    pathList.AddRange(GetDirSubFilePathList(d.FullName, isRecursive, suffix));
                }
            }

            return pathList;
        }

        public static System.Collections.Generic.List<string> GetDirSubDirNameList(this string dirABSPath)
        {
            var di = new DirectoryInfo(dirABSPath);

            var dirs = di.GetDirectories();

            return dirs.Select(d => d.Name).ToList();
        }

        public static string GetFileName(this string absOrAssetsPath)
        {
            var name = absOrAssetsPath.Replace("\\", "/");
            var lastIndex = name.LastIndexOf("/");

            return lastIndex >= 0 ? name.Substring(lastIndex + 1) : name;
        }

        public static string GetFileNameWithoutExtend(this string absOrAssetsPath)
        {
            var fileName = GetFileName(absOrAssetsPath);
            var lastIndex = fileName.LastIndexOf(".");

            return lastIndex >= 0 ? fileName.Substring(0, lastIndex) : fileName;
        }

        public static string GetFileExtendName(this string absOrAssetsPath)
        {
            var lastIndex = absOrAssetsPath.LastIndexOf(".");

            if (lastIndex >= 0)
            {
                return absOrAssetsPath.Substring(lastIndex);
            }

            return string.Empty;
        }

        public static string GetDirPath(this string absOrAssetsPath)
        {
            var name = absOrAssetsPath.Replace("\\", "/");
            var lastIndex = name.LastIndexOf("/");
            return name.Substring(0, lastIndex + 1);
        }

        public static string GetLastDirName(this string absOrAssetsPath)
        {
            var name = absOrAssetsPath.Replace("\\", "/");
            var dirs = name.Split('/');

            return absOrAssetsPath.EndsWith("/") ? dirs[dirs.Length - 2] : dirs[dirs.Length - 1];
        }


        #endregion
}
