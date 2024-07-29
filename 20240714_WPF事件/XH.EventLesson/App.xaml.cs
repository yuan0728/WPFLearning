using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace XH.EventLesson
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // 生命周期
            // APP 启动的时候 触发
            this.Startup += App_Startup;
            // APP 退出时触发
            this.Exit += App_Exit;

            // 操作系统退出的时候触发
            this.SessionEnding += App_SessionEnding;
            // Dispatche UI 线程 未被处理的异常 最后一道关卡 
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            // 全局处理 全局捕获异常 但是不可以捕获Task的异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            // 处理Task没有捕获到全局异常
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }
        // 在垃圾回收机制触发的时候，才能捕捉到异常
        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // 可以记录下日志
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            // 操作系统关闭时触发
            // 关闭电脑是 弹出 仍要关闭/取消 按钮
            e.Cancel = true;
        }

        // 如果没有任何窗口运行 则启用这个方法 退出
        // 杀进程 不调用此方法
        private void App_Exit(object sender, ExitEventArgs e)
        {
            // 日志记录 数据保存
            Debug.WriteLine("APP---Exit");
        }

        // 被动调用
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        // 上下两个方法一样

        /// <summary>
        /// APP开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">获取命令行参数</param>
        /// <exception cref="NotImplementedException"></exception>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            // 需求：当程序运行的时候 exe 传递参数 dotnet run .....
            // 更新：更新程序不允许双击打开  主程序获取更新列表提交到更新程序
            // Main.exe 需要收参数 
            // 调试版本（更多的日志输出）/生产版本（执行效率）
            // 业务场景：应用独立启动 不允许多开，可以在这里检查进程
            // MessageBox.Show(string.Join(',',e.Args));
        }
    }

}
