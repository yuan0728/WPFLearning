using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace XH.PrismDialog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册弹窗内容
            containerRegistry.RegisterDialog<UCDetail>("Detail");

            // 注册弹窗窗口，这句代码会将框架内的默认弹窗窗口替换掉
            containerRegistry.RegisterDialogWindow<DialogParent>();
        } 
    }

}
