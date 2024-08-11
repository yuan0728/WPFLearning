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
    public class ViewCViewModel : INavigationAware
    {
        public IRegionNavigationJournal Journal { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand ForwordCommand { get; set; }

        public ViewCViewModel(IRegionManager regionManager)
        {
            GoBackCommand = new DelegateCommand(() =>
            {
                if (Journal.CanGoBack)
                    Journal.GoBack();
            });

            ForwordCommand = new DelegateCommand(() =>
            {
                if (Journal.CanGoForward)
                    Journal.GoForward();
                else
                {
                    // 下一步打开ViewB
                    regionManager.RequestNavigate("MainRegion", "ViewA");
                }
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Journal = navigationContext.NavigationService.Journal;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
