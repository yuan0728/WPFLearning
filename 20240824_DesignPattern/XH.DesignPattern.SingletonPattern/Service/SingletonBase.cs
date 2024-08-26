using System;
using System.Collections.Generic;
using System.Text;

namespace XH.DesignPattern.SingletonPattern.Service
{
    public class SingletonBase<T> where T : class, new()
    {
        private static T _Instance;

        private static object ObjLock = new object();

        /// <summary>
        /// 双判断+锁
        /// </summary>
        /// <returns></returns>
        public static T CreateInstanc()
        {
            if (_Instance == null)
            {
                lock (ObjLock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new T();
                    }
                }
            }
            return _Instance;
        }
    }
}
