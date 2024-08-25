using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.ProxyPattern
{
    /// <summary>
    /// 第三方缓存 能在内存中差常驻数据  且能获取
    /// </summary>
    public class CustomCache
    {
        private static Dictionary<string, object> CustomCacheDictionary = new Dictionary<string, object>
            ();
        public static void Add(string key, object value)
        {
            CustomCacheDictionary.Add(key, value);
        }
        public static T Get<T>(string key)
        {
            return (T)CustomCacheDictionary[key];
        }
        public static bool Exist(string key)
        {
            return CustomCacheDictionary.ContainsKey(key);
        }
    }
}
