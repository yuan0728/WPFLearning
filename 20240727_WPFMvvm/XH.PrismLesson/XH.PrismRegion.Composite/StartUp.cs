using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using XH.PrismRegion.Composite.Views;

namespace XH.PrismRegion.Composite
{
    public class StartUp : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();

            containerRegistry.RegisterSingleton<CompositeCommand>();
        }
    }
}
