using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismRegion.Composite.ViewModels
{
    public class ViewBViewModel : INavigationAware
    {
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        public DelegateCommand SaveCommand { get; set; }

        public ViewBViewModel(CompositeCommand compositeCommand)
        {
            SaveCommand = new DelegateCommand(() =>
            {

            });

            compositeCommand.RegisterCommand(SaveCommand);
            // 退出的时候需要退出一下
            //compositeCommand.UnregisterCommand(SaveCommand);
        }
    }
}
