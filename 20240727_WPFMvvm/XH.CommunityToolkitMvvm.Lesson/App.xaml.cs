using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Configuration;
using System.Data;
using System.Windows;

namespace XH.CommunityToolkitMvvm.Lesson
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // 实例化 IOC容器 并且添加注册
        static ServiceCollection service = new ServiceCollection();
        public static IServiceProvider Service { get; private set; }

        public App()
        {
            InitializeComponent();
            service.AddSingleton<MainViewModel>();

            Service = service.BuildServiceProvider();

            // 释放
            service.RemoveAll<MainViewModel>();
        }

        public static void Cleanup<T>() where T : IDisposable
        {
            Service.GetService<T>().Dispose();

            service.RemoveAll<T>();
        }

    }
}
