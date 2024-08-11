using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;
using XH.PrismViewModelLocator.ViewModels;
using XH.PrismViewModelLocator.Views;

namespace XH.PrismViewModelLocator
{
    public class StartUp : PrismBootstrapper
    {
        /*
            Prism自动关联ViewModel的规则
            View的类名称非View结尾的时候，解析ViewModel的类名称时候，后面需要加上ViewModel
            View的类名称为View结尾的时候，解析ViewModel的类名称时候，后面需要加上Model
         */
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<LoginView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        // 处理View ViewModel之间的关系 自定义匹配
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // 1、配置默认的匹配规则
            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(TypeResolver);
            // 2、明确指定特性的ViewModel关系
            //ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
            //
            //ViewModelLocationProvider.Register("MainWindow", typeof(MainWindowViewModel));
            //
            //ViewModelLocationProvider.Register("MainWindow", CreateMainViewModel);
            //
            //ViewModelLocationProvider.Register<MainWindow>(CreateMainViewModel);
        }

        private object CreateMainViewModel() => Container.Resolve<MainWindowViewModel>();

        /*
           默认：Prism自动关联ViewModel的规则
           View的类名称非View结尾的时候，解析ViewModel的类名称时候，后面需要加上ViewModel
           View的类名称为View结尾的时候，解析ViewModel的类名称时候，后面需要加上Model
        */
        private Type TypeResolver(Type viewType)
        {
            //XH.PrismViewModelLocator.Views.MainWindow
            //XH.PrismViewModelLocator.ViewModels.MainWindowViewModel
            //XH.PrismViewModelLocator.Views.LoginView
            //XH.PrismViewModelLocator.ViewModels.LoginViewModel

            var vmName = viewType.FullName.Replace(".Views", ".ViewModels");

            if (vmName.EndsWith("View"))
                vmName += "Model";
            else
                vmName += "ViewModel";

            return Type.GetType(vmName);
        }
    }
}
