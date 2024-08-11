using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismModule
{
    public class MainWindowViewModel
    {
        public DelegateCommand OpenCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager,IModuleManager moduleManager)
        {
            OpenCommand = new DelegateCommand(() =>
            {
                // 加载模块 OnDemand =true 如果开启懒加载的话 需要手动加载
                //moduleManager.LoadModule("AAA");
                regionManager.RequestNavigate("MainRegion","ViewA");
            });
        }
    }
}
