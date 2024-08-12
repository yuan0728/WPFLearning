using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XH.CMLesson.WM.ViewModels;

namespace XH.CMLesson.WM
{
    public class StartUp : BootstrapperBase
    {
        private SimpleContainer _container;

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
        protected override void Configure()
        {
            // 注册IOC容器
            _container = new SimpleContainer();
            // 注册接口和实现
            this._container.Singleton<IEventAggregator, EventAggregator>();
            this._container.Singleton<IWindowManager, WindowManager>();
            // 注册ViewModel
            this._container.PerRequest<MainViewModel>();
            this._container.PerRequest<AViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            // 解析ViewModel之前 获取实例
            return this._container.GetInstance(service, key);
        }
    }
}
