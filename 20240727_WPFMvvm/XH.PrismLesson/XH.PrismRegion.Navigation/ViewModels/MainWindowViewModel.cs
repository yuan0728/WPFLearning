using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// 如果发现ViewModel自动匹配不上
// 1、检查对应的类型名称是否符合要求
// 2、检查自动匹配的ViewModel是否有无法注入的对象
namespace XH.PrismRegion.Navigation.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand OpenCommand { get; set; }

        // 区域管理 需要拿到 IRegionManager
        IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            OpenCommand = new DelegateCommand<string>(DoOpenView);
        }

        private void DoOpenView(string viewName)
        {
            //_regionManager.RegisterViewWithRegion("ViewRegion", viewName);
            // 打开/显示 某个View的时候 希望给个参数给它 
            // 上面的语句不可以传参
            // 需要请求的View需要先注册到容器中
            // 向目标View中传递特定的参数 参数对接到View的ViewModel中
            if (viewName == "ViewA")
            {
                NavigationParameters parmaters = new NavigationParameters();
                parmaters.Add("A", "Hello");
                _regionManager.RequestNavigate("ViewRegion", viewName, parmaters);
            }
            else if (viewName == "ViewB")
            {
                _regionManager.RequestNavigate("ViewRegion", viewName);
            }
        }
    }
}
