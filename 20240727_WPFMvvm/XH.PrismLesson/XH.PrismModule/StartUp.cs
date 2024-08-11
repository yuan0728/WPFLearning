using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System.Windows;

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

        // 配置模块注册
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // 第一种方式
            //moduleCatalog.AddModule<AModule>();

            // 第二种方式
            //Type type = typeof(AModule);
            //moduleCatalog.AddModule(new ModuleInfo
            //{
            //    ModuleName = type.Name,
            //    ModuleType = type.AssemblyQualifiedName,
            //    // 标记Module按需加载 懒加载
            //    InitializationMode = InitializationMode.OnDemand,
            //});
        }

        // 创建模块注册
        // 同过配置文件 完全解耦
        // 第三种通过配置文件注册
        protected override IModuleCatalog CreateModuleCatalog()
        {
            // 第三种方式：
            // APP.config
            // 这里可以不用引用对应的 Module 程序集
            //return new ConfigurationModuleCatalog();

            // 第四种：XML文件配置
            // 所有需要加载的Module程序集 必须由当前程序集引用
            //return new XamlModuleCatalog(".\\ModuleConfig.xml");
            //return new XamlModuleCatalog("pack://application:,,,/XH.PrismModule;component/ModuleConfig.xml");

            // 第五种方式：(推荐)
            // 需要在bin/Debug 下有 ModulePath 目录，进行扫描
            return new DirectoryModuleCatalog()
            {
                // 配置将要扫描的目录
                ModulePath = ".\\ModulePath"
            };
        }
    }
}
