using System.Collections.Concurrent;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XH.ThreadDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static readonly object obj_lock = new object();
        /// <summary>
        /// 线程ID：任何一个线程都有一个独一无二的线程id
        /// 主线程/UI线程：ID = 1
        /// 
        /// 特点：
        /// 1、多线程不会阻塞UI/主线程 -- 多线程是延迟启动
        /// 2、多线程的启动和执行完毕，没有顺序，无序性
        /// 3、多线程效率会更高 -- 多线程具有并发性 -- 多线程不节省资源 -- 消耗更多的资源来换时间 -- 提高效率
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId.ToString("000")} Thread_Click Start");
            //Task.Run(() =>
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId.ToString("000")} 启动了一个线程");
            //});
            //Thread.Sleep(1000 * 2);
            //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId.ToString("000")} Thread_Click End");

            Show1();

            Show2();

            // 设置线程池大小
            //ThreadPool.SetMaxThreads(0,0);

        }

        private void Show1()
        {
            for (int i = 0; i < 100000000; i++)
            {

            }
            Thread.Sleep(1000 * 2);
        }

        private void Show2()
        {
            for (int i = 0; i < 100000000; i++)
            {

            }
            Thread.Sleep(1000 * 2);
        }

        /* 
         * C#中的多线程 
         * .NET Framework 1.0 Thread -- 可以操作线程的类库
         * .NET Framework 2.0 ThreadPool -- 线程池
         * .NET Framework 3.0 -- .NET8 Task -- 一直是最受欢迎的最佳实现：丰富的API
         */

        // Thread.CurrentThread.ManagedThreadId：线程ID
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            #region C#中启动线程的方法：

            // 1、直接New 
            //Task task = new Task(() =>
            //{
            //    Console.WriteLine($"Start Thread -- {Thread.CurrentThread.ManagedThreadId.ToString("000")}");
            //});
            //task.Start();
            // 2、Task.Run
            //Task.Run(() =>
            //{
            //    Console.WriteLine($"Start Thread -- {Thread.CurrentThread.ManagedThreadId.ToString("000")}");
            //});
            // 3、TaskFactory
            //TaskFactory taskFactory = new TaskFactory();
            //taskFactory.StartNew(() =>
            //{
            //    Console.WriteLine($"Start Thread -- {Thread.CurrentThread.ManagedThreadId.ToString("000")}");
            //});
            // 4、Task.Factory.StartNew
            //Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"Start Thread -- {Thread.CurrentThread.ManagedThreadId.ToString("000")}");
            //});

            #endregion

            #region 线程的等待 Thread.Sleep 和 Task.Delay 的区别
            // 查询数据 -- 启动线程去查询数据 -- 等待返回数据
            // 建议使用 Task.Delay 

            // 等待主线程 直接卡顿界面 影响用户的体验
            //Thread.Sleep(1000);
            // 不会等待主线程 一般伴随 ContinueWith 一起使用
            // 表示等待多长时间之后 可以执行一个回调方法
            //Task.Delay(1000).ContinueWith(task => { });

            #endregion

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                int k = i;
                tasks.Add(Task.Factory.StartNew(o =>
                {
                    Console.WriteLine($"开始逻辑：{k}");
                    Thread.Sleep(200);
                    Console.WriteLine($"结束逻辑：{k}");
                }, $"任务{k}"));
                //tasks.Add(Task.Run(() =>
                //{
                //    Console.WriteLine($"逻辑：{Thread.CurrentThread.ManagedThreadId.ToString("000")}");
                //}));
            }
            // 1、如果希望所有的线程都执行结束后，再执行一段业务逻辑
            // 等待（等待主线程/UI线程）所有线程执行完 才执行以下业务 会卡顿界面 
            //Task.WaitAll(tasks.ToArray()); 
            //Console.WriteLine("线程执行结束后执行此业务逻辑！！！");

            // 2、如果希望这一堆任务中，其中只要有一个任务执行完毕就继续往后执行
            // 等待（等待主线程/UI线程）任一一个线程执行完 才执行以下业务 会卡顿界面 
            //Task.WaitAny(tasks.ToArray());
            //Console.WriteLine("只要有一个任务执行完毕就继续往后执行！！！");

            // 3、既等待也不卡界面的等待方式 等待一堆线程执行完之后 继续往下执行
            // 等待一堆线程执行完之后 继续往下执行
            //Task.Factory.ContinueWhenAll(tasks.ToArray(), taskList =>
            //{
            //    Console.WriteLine("不卡顿界面所有线程执行之后继续往后执行！！！");
            //});
            // 4、既等待也不卡界面的等待方式 等待一堆线程中，任何一个线程执行完之后 继续往下执行
            Task.Factory.ContinueWhenAny(tasks.ToArray(), task =>
            {
                // task：结束的线程
                // task.AsyncState：哪个线程结束了
                Console.WriteLine($"{task.AsyncState}执行结束：不卡顿界面任何一个线程执行完之后继续往后执行！！！");
            });
        }

        // 线程安全
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            #region 多线程异常处理

            // 在多线程的内部发生的异常 外部的 try-catch 是捕捉不到的
            // 如果把 try-catch 写在task内部可以捕捉到，不过是单个线程的捕捉
            // 捕捉异常：线程等待 Task.WaitAll 
            // 捕捉到的多线程异常，有什么特点：AggregateException：类型的异常
            // 一个 try 可以对应多个 catch，异常类型的匹配优先具体类型，如果没有再匹配抽象
            //try
            //{
            //    List<Task> taskList = new List<Task>();
            //    for (int i = 0; i < 20; i++)
            //    {
            //        int k = i;
            //        taskList.Add(Task.Run(() =>
            //        {
            //            if (k == 6)
            //                throw new Exception("k == 6");
            //            if (k == 9)
            //                throw new Exception("k == 9");
            //            if (k == 11)
            //                throw new Exception("k == 11");
            //        }));
            //    }
            //    Task.WaitAll(taskList.ToArray());
            //}
            //// 如果多个catch 优先匹配具体类型 如果没有才会去匹配抽象
            //catch (AggregateException ex)
            //{
            //    foreach (var item in ex.InnerExceptions)
            //    {
            //        Console.WriteLine(item.Message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            #endregion

            #region 线程取消 -- 把一些没有必要执行的线程停止掉

            //// 线程不能从外部取消，线程只能自己取消自己
            //// 来一个信号量：每个线程去判断这个信号量，如果有线程发生异常了，就去修改这个信号量
            ////bool isGoOn = true;
            //// 线程取消的标准方案：CancellationTokenSource，提供IsCancellationRequested属性，默认值为false
            ////  同时提供Cancel方法， IsCancellationRequested： false --> true

            //// 取消还没有判断的线程
            //// 如果取消，就要让准备启动但是还没有启动的线程停止下来
            //CancellationTokenSource cts = new CancellationTokenSource();
            //List<Task> taskList = new List<Task>();
            //for (int i = 0; i < 200; i++)
            //{
            //    int k = i;
            //    taskList.Add(Task.Run(() =>
            //    {
            //        // 线程取消 只能取消还没有判断的线程
            //        if (cts.IsCancellationRequested)
            //        {
            //            Console.WriteLine($"开始：{Thread.CurrentThread.ManagedThreadId.ToString("000")}");
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Cancel结束：{Thread.CurrentThread.ManagedThreadId.ToString("000")}");
            //            cts.Cancel();
            //        }
            //        if (k == 6)
            //            cts.Cancel();
            //    },cts.Token));
            //}

            #endregion

            #region 临时变量

            //// 多线程：延时启动不会阻塞主线程 
            //// 因为task启动的时候需要请求计算机需要内存然后去启动，这个时候for循环如果很少的话，就会执行完毕，导致i为最大的++
            //// 如果需要一个中间变量去接受i，然后输出，必须在循环里面：因为每次循环都是新的变量，如果把变量定义在for循坏外面则和输出i一样。
            //for (int i = 0; i < 20; i++)
            //{
            //    int k = i;
            //    Task.Run(() =>
            //     {
            //         Console.WriteLine(k);
            //     });
            //}

            #endregion

            #region 线程安全 -- 多线程和单线程执行逻辑一致就是线程安全

            int Num = 0;
            for (int i = 0; i < 1000_0; i++)
            {
                Num++;
            }
            Console.WriteLine(Num);  // Num = 1000_0

            List<Task> taskList = new List<Task>();
            int AsyncNum = 0;
            for (int i = 0; i < 1000_0; i++)
            {
                taskList.Add(Task.Run(() =>
                {
                    lock (obj_lock)
                    {
                        AsyncNum++;
                    }
                }));
            }
            Task.WaitAll(taskList.ToArray());
            Console.WriteLine(AsyncNum);  // AsyncNum < 1000_0

            // ============ 以上 多线程是不安全的 并发导致的安全问题 ================
            /* 1.加锁：标准锁：锁静态对象
             *      private static readonly object obj_lock = new object();
             * 2.使用线程安全集合：
             *      ConcurrentDictionary<>
             * 3.分片执行：
             *      出现线程安全的主要场景，多个线程同时去操作变量、同时操作计算机文件
             *      避开让多个线程有机会同时去操作同一块数据
             */

            #endregion
        }
    }
}