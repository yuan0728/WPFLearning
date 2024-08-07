using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace XH.PrismInitialize
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            // 初始化第二种方式
            // 当非APP启动的时候 可以使用PrismBootstrapper来处理
            //new StartUp().Run();
        }
        // 初始化第一种方式
        // 提供主窗口的对象
        protected override Window CreateShell()
        {
            return new MainWindow() { Title = "Prism Start"};
        }

        // 业务中所需要的注入对象，在这个方法里注册
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
