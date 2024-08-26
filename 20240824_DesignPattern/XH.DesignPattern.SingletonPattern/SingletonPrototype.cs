using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XH.DesignPattern.SingletonPattern
{
    /// <summary>
    /// 原型模式
    /// </summary>
    public class SingletonPrototype
    {
        private SingletonPrototype()
        {
            long lResult = 0;
            for (int i = 0; i < 10000000; i++)
            {
                lResult += i;
            }
            Thread.Sleep(2000);
            Console.WriteLine($"{GetType().Name}被构造一次 {Thread.CurrentThread.ManagedThreadId}");
        }

        public static SingletonPrototype CreateInstance()
        {
            //MemberwiseClone： 内存拷贝；  不是浅拷贝
            object oInstance = _SingletonPrototype.MemberwiseClone();
            return (SingletonPrototype)oInstance;
        }


        private static SingletonPrototype _SingletonPrototype = new SingletonPrototype();

        public int Id { get; set; }
        public string Name { get; set; }

        public static void Show()
        {
            _SingletonPrototype.ToString();
            Console.WriteLine(" Show 方法~~");
        }
    }
}
