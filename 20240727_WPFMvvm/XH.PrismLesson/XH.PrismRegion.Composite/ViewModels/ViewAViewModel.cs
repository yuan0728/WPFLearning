using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismRegion.Composite.ViewModels
{
    public class ViewAViewModel : INavigationAware
    {
        CompositeCommand _compositeCommand;
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            _compositeCommand.UnregisterCommand(SaveCommand);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public DelegateCommand SaveCommand { get; set; }

        public ViewAViewModel(CompositeCommand compositeCommand)
        {
            _compositeCommand = compositeCommand;
            SaveCommand = new DelegateCommand(() =>
            {

            });

            // 这里的前后关系很重要
            _compositeCommand.RegisterCommand(SaveCommand);

            // 退出的时候 需要退出一下
            //compositeCommand.UnregisterCommand(SaveCommand);
        }
    }
}
