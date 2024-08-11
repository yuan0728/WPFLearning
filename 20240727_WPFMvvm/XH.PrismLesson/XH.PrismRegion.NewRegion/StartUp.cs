using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using XH.PrismRegion.NewRegion.Views;

namespace XH.PrismRegion.NewRegion
{
    public class StartUp : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册需要导航的子页面，只有注册了才能处理
            containerRegistry.RegisterForNavigation<SubView>();

            // 注册弹窗
            containerRegistry.RegisterDialog<DialogView>();
        }
    }
}
