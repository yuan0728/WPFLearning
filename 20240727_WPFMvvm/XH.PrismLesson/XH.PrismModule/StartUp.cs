using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using XH.PrismModule.ModuleA;

namespace XH.PrismModule
{
    public class StartUp : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        // 模块注册
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AModule>();
        }
    }
}
