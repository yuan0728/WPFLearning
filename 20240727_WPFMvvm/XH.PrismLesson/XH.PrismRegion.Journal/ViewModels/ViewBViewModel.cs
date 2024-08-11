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
    // 通过导航记录来回到上一页 下一页
    public class ViewBViewModel : INavigationAware, IJournalAware
    {
        public IRegionNavigationJournal Journal { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand ForwordCommand { get; set; }

        public ViewBViewModel(IRegionManager regionManager)
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
                    regionManager.RequestNavigate("MainRegion", "ViewC");
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

        // IJournalAware：的方法实现
        // 是否保存在历史记录中
        public bool PersistInHistory() => false;
    }
}
