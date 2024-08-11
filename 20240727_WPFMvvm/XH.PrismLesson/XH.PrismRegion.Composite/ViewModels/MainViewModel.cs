using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismRegion.Composite.ViewModels
{
    public class MainViewModel
    {
        // 多个命令整合一起
        public CompositeCommand AllSaveCommand { get; set; }
        public DelegateCommand ShowPageCommand { get; set; }

        public MainViewModel(IRegionManager regionManager, CompositeCommand compositeCommand)
        {
            ShowPageCommand = new DelegateCommand(() =>
            { 
                regionManager.RequestNavigate("Region1", "ViewA");
                regionManager.RequestNavigate("Region2", "ViewB");
            });

            AllSaveCommand = compositeCommand;
            //AllSaveCommand.RegisterCommand(ShowPageCommand);
        }
    }
}
