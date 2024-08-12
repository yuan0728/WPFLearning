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
    // 是一个以ViewModel为中心的MVVM框架
    public class StartUp:BootstrapperBase
    {
        public StartUp()
        {
            // 初始化
            this.Initialize();

            // 自定义命令参数 只能写在ViewModel 和项目起始中使用，不可以在View中使用
            MessageBinder.SpecialValues.Add("$xiaoHai", OnXiaoHaiValue);
        }
        private object OnXiaoHaiValue(ActionExecutionContext context)
        {
            return "Little Sea";
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
