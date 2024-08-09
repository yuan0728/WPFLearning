using Prism.Events;
using Prism.Ioc;
using Prism.Unity;
using System.Configuration;
using System.Data;
using System.Windows;

namespace XH.PrismEventAggregator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            // 静态注入
            Messenger.Defualt = Container.Resolve<IEventAggregator>();

            //new SubWindow().Show();
            // 第一种
            //var ea = Container.Resolve<IEventAggregator>();
            //return new MainWindow(ea) { Title = "Prism Start" };

            // 第二种
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }

}
