using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using XH.PrismRegion.Base.Views;

namespace XH.PrismRegion.Base
{
    public class StartUp : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册需要导航的子页面，只有注册了才能处理
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
        }
    }
}
