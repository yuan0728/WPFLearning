using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XH.DesignPattern.SingletonPattern
{
    public class Singleton
    {
        /// <summary>
        /// 构造函数耗时耗资源
        /// 1.私有化构造函数
        /// </summary>
        private Singleton()
        {
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{GetType().Name}被构造一次 {Thread.CurrentThread.ManagedThreadId}");
        }


        /// <summary>
        /// 2. 对外提供一个返回Singeton实例的的方式 
        /// 双判断+锁单例模式；
        /// </summary>
        /// <returns></returns>
        public static Singleton CreateInstance()
        {
            //1. 第一波：来了四个线程 _Singleton=null; 
            //2. 第一波结束后，当前 _Singleton不等于null;再来4个线程并发   但是锁会影响并发（影响性能）
            //  ??? 
            if (_Singleton == null)
            {
                lock (_SingletonLock)
                {
                    if (_Singleton == null)
                    {
                        _Singleton = new Singleton();
                    }
                }
            }
            return _Singleton;
        }

        /// <summary>
        /// 3. 定义一个静态的变量用来存储当前的对象
        /// 静态变量： 常驻内存，只要是进程还在，这个变量一直保存在内存中；
        /// </summary>
        private static Singleton _Singleton;
        private static object _SingletonLock = new object();


        public int Id { get; set; }
        public string Name { get; set; }

        public static void Show()
        {
            Console.WriteLine(" Show 方法~~");
        }
    }
}
