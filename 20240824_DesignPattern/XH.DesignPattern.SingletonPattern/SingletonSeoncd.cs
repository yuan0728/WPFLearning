using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XH.DesignPattern.SingletonPattern
{
    /// <summary>
    /// 单例模式第二种 -- 静态构造函数
    /// </summary>
    public class SingletonSeoncd
    {
        private SingletonSeoncd()
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
        /// 静态构造函数：特点
        ///     在整个进程中，执行且只执行一次的；
        /// </summary>
        static SingletonSeoncd()
        {
            _SingletonSeoncd = new SingletonSeoncd();
        }

        public static SingletonSeoncd CreateInstance()
        {
            return _SingletonSeoncd;
        }

        private static SingletonSeoncd _SingletonSeoncd;

        public int Id { get; set; }
        public string Name { get; set; }

        public static void Show()
        {
            Console.WriteLine(" Show 方法~~");
        }
    }
}
