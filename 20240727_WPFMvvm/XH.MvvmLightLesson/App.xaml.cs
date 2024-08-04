using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using System.Configuration;
using System.Data;
using System.Windows;
using XH.MvvmLightLesson.ViewModels;

namespace XH.MvvmLightLesson
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static SimpleIoc _simpleIoc = SimpleIoc.Default;
        public App()
        {
            // DispatcherHelper 初始化
            //DispatcherHelper.Initialize();

            // SimpleIoc 全局注册
            // 向SimpleIoc对象中，添加一个类型
            //_simpleIoc.Register<MainViewModel>();

            // 从SimpleIoc对象中获取指定类型的实例（指定创建实例）
            //MainViewModel model = _simpleIoc.GetInstance<MainViewModel>();
        }

        //public static MainViewModel MainVM { get => _simpleIoc.GetInstance<MainViewModel>(); }
    }

}
