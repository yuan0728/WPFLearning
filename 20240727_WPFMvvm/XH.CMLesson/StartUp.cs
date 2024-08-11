using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XH.CMLesson.ViewModels;

namespace XH.CMLesson
{
    public class StartUp:BootstrapperBase
    {
        public StartUp()
        {
            // 初始化
            this.Initialize();
        }
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            // 启动ViewModel 的 页面是View 
            // 默认约定 MainViewModel --> MainView
            // 启动
            await DisplayRootViewForAsync<MainViewModel>();
        }
    }
}
