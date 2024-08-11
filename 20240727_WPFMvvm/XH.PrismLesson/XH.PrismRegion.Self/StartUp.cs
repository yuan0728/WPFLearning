using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;

namespace XH.PrismRegion.Self
{
    public class StartUp : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<RegionView>();
        }
    }
}
