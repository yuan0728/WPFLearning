using XH.DesignPattern.SingletonPattern.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace XH.DesignPattern.SingletonPattern
{
    /// <summary>
    /// 同学们，听一首歌，然后再开始，
    /// 容Eleven准备一下，刚吃完饭。。今天搞太晚了~
    /// </summary>
    public class Program
    {
        public Program()
        {
            Console.WriteLine("2445");
        }

        public static void Main()
        {
            {
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                //{
                //    Singleton singleton1 = new Singleton(); //执行构造函数
                //    Singleton singleton2 = new Singleton(); //执行构造函数
                //    Singleton singleton3 = new Singleton(); //执行构造函数
                //    Singleton singleton4 = new Singleton(); //执行构造函数
                //}
                //stopwatch.Stop();
                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }
            //对象创建 很耗时耗资源；  ----原因：要执行构造函数---构造函数很耗时耗资源； 
            //???? 能不能不去执行构造函数？----不能
            //减少构造函数的执行；  如果只执行一次构造函数

            //创建这个对象的事后，可以让其只执行一次构造函数；----在内存中，也就只有这一个实例；-----单例模式；


            //一、单例模式的经典玩法
            // 单例： 只有一个实例--- 必然只能执行一次构造函数
            //        无论是单线程还是多线程---必须只能创建一个实例
            //问题： 现有的代码---多线程---并不能保证单例；
            //       1. 加锁--会影响性能
            //Console.WriteLine("------------------------------------");
            //{
            //    Stopwatch stopwatch = new Stopwatch();
            //    stopwatch.Start(); 
            //    for (int i = 0; i < 4; i++)
            //    {
            //        Task.Run(() =>
            //        {
            //            Singleton singleton1 = Singleton.CreateInstance(); 
            //        });
            //    } 
            //    stopwatch.Stop();
            //    Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //} 
            //Singleton.Show();
            //最经典单例：双判断+锁-----懒汉式单例---必须要执行CreateInstance才会创建实例；


            //单例模式封装之后
            {

                //PersonService personService= new PersonService(); 
                //PersonService personService1 = SingletonBase<PersonService>.CreateInstanc();
                //UserService userService = SingletonBase<UserService>.CreateInstanc(); 
            }


            Console.WriteLine("------------------------------------");
            {
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                //for (int i = 0; i < 4; i++)
                //{
                //    Task.Run(() =>
                //    {
                //        SingletonSeoncd singleton1 = SingletonSeoncd.CreateInstance();
                //    });
                //}
                //stopwatch.Stop();
                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }

            //静态构造函数初始化变量值：
            //SingletonSeoncd.Show();  //饿汉式单例，没有执行CreateInstance方法，就已经初始化了这个单例的实例了；

            {
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                //for (int i = 0; i < 4; i++)
                //{
                //    Task.Run(() =>
                //    {
                //        SingletonThird singleton1 = SingletonThird.CreateInstance();
                //    });
                //}
                //stopwatch.Stop();
                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            }

            //SingletonThird.Show(); ////饿汉式单例，没有执行CreateInstance方法，就已经初始化了这个单例的实例了；


            //单例模式： 只有一个实例；---同一个内存的指向； 
            {
                //Singleton singleton1 = Singleton.CreateInstance();  
                //singleton1.Id = 123;
                //singleton1.Name = "Richard";

                //Singleton singleton2 = Singleton.CreateInstance();
                //singleton2.Id = 3345;
                //singleton2.Name = "朝夕教育";

                //无论是 singleton1  还是 singleton2  其实都是同一个实例；
            }
            //又希望 能够的快速的创建对象，但是我又希望不要出现上面这种污染；

            //原型模式： 既要快速的创建对象（不能每次都执行构造函数） MemberwiseClone: 内存复制；

            {
                //SingletonPrototype singleton1 = SingletonPrototype.CreateInstance();
                //singleton1.Id = 123;
                //singleton1.Name = "Richard";

                //SingletonPrototype singleton2 = SingletonPrototype.CreateInstance();
                //singleton2.Id = 3345;
                //singleton2.Name = "朝夕教育";

            }
            //原型模式：
            //既保证了单例： 快速创建对象；
            {
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                //List<Task> tasks = new List<Task>();
                //for (int i = 0; i < 4; i++)
                //{
                //    tasks.Add(Task.Run(() =>
                //    {
                //        SingletonPrototype singleton1 = SingletonPrototype.CreateInstance();
                //    }));
                //}

                //Task.WaitAll(tasks.ToArray());
                //stopwatch.Stop();
                //Console.WriteLine($"时间：{stopwatch.ElapsedMilliseconds}  ");
            }

            //SingletonPrototype singleton1 = SingletonPrototype.CreateInstance();
            //SingletonPrototype singleton2 = SingletonPrototype.CreateInstance();
            //SingletonPrototype singleton3 = SingletonPrototype.CreateInstance();
            //SingletonPrototype singleton4 = SingletonPrototype.CreateInstance();

            //Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
            //Console.WriteLine(object.ReferenceEquals(singleton1, singleton3));


            //单例：需要让整个进程保持是一个实例---单例
            //原型：需要快速的创建对象； 原型；
        }
    }
}
