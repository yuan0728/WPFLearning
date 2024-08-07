using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XH.PrismInitialize
{
    // 启动项
    public class StartUp : PrismBootstrapper
    {

        // 提供主窗口的对象
        protected override DependencyObject CreateShell()
        {
            return new MainWindow() { Title = "Prism Start" };
        }

        // 业务中所需要的注入对象，在这个方法里注册
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
