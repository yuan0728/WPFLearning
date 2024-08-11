using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XH.PrismRegion.Journal.ViewModels
{
    public class MainViewModel
    {
        public ICommand BtnLoadCommand { get; set; }

        IRegionManager _regionManager;
        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            BtnLoadCommand = new DelegateCommand(DoLoad);
        }

        private void DoLoad()
        {
            _regionManager.RequestNavigate("MainRegion","ViewA");
        }
    }
}
