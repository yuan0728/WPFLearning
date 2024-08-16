using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XH.CMLesson.MultiPage.ViewModels;
using XH.CMLesson.MultiPage.Views;

namespace XH.CMLesson.MultiPage
{
    public class StartUp : BootstrapperBase
    {
        private SimpleContainer _container;

        public StartUp()
        {
            // 初始化
            this.Initialize();

            ViewLocator.LocateForModelType = new Func<Type, DependencyObject, object, UIElement>(OnLocateForModelType);
        }

        // 通过类型匹配ViewModel
        private UIElement OnLocateForModelType(Type type, DependencyObject d, object obj)
        {
            // MainViewModel的全名称
            string name = type.FullName;
            name = name.Replace(".ViewModels", ".Views");
            if (name.EndsWith("Model"))
                name = name.Substring(0, name.Length - 5);

            var t = Assembly.GetExecutingAssembly().GetType(name);

            // 可以加入View的依赖注入功能

            return (UIElement)Activator.CreateInstance(t);
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
            this._container.Singleton<IChildViewModel, AViewModel>("A");
            this._container.Singleton<IChildViewModel, BViewModel>("B");
            this._container.Singleton<IChildViewModel, CViewModel>("C");

        }

        protected override object GetInstance(Type service, string key)
        {
            // 解析ViewModel之前 获取实例
            return this._container.GetInstance(service, key);
        }
    }
}
