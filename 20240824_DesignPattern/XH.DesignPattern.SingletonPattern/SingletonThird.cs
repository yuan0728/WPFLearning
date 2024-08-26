using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XH.DesignPattern.SingletonPattern
{
    /// <summary>
    /// 声明静态变量的时候 初始化 
    /// </summary>
    public class SingletonThird
    {
        private SingletonThird()
        {
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{GetType().Name}被构造一次 {Thread.CurrentThread.ManagedThreadId}");
        }

        public static SingletonThird CreateInstance()
        {
            return _SingletonThird;
        }

        private static SingletonThird _SingletonThird = new SingletonThird();

        public int Id { get; set; }
        public string Name { get; set; }

        public static void Show()
        {
            Console.WriteLine(" Show 方法~~");
        }
    }
}
