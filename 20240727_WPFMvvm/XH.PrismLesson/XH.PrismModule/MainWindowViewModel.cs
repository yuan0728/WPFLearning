using Prism.Commands;
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
        public MainWindowViewModel(IRegionManager regionManager)
        {
            OpenCommand = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate("MainRegion","ViewA");
            });
        }
    }
}
