using Prism.Commands;
using Prism.Regions;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

// 界面来看 数据没有绑定上
// 1、数据关系不对：XAML绑定失败窗口
// 2、ViewModel没有匹配上 匹配格式不对 

namespace XH.PrismRegion.Navigation.ViewModels.Pages
{
    // IRegionMemberLifetime：声明周期
    public class ViewAViewModel : INavigationAware, IRegionMemberLifetime, IConfirmNavigationRequest
    {
        public string Title { get; set; } = "View A";
        public ICommand CloseTabCommand { get; set; }
        IRegionManager _regionManager;
        public ViewAViewModel(
            IRegionNavigationService regionNavigationService,
            IRegionNavigationJournal regionNavigationJournal,
            IRegionManager regionManager)
        {
            _regionManager = regionManager;
            // 导航历史记录 操作
            regionNavigationService.Journal.GoBack();
            regionNavigationJournal.GoBack();

            CloseTabCommand = new DelegateCommand(DoCloseTab);
        }

        private void DoCloseTab()
        {
            //_regionManager.Regions.Remove("ViewRegion");
            var region = _regionManager.Regions["ViewRegion"];
            var view = region.Views.FirstOrDefault(v => v.GetType().Name == "ViewA");
            region.Remove(view);

            // 关闭所有
            //region.RemoveAll();
        }

        #region IRegionMemberLifetime 方法

        // 用来控制当前页面非激活状态，是否在Region中保留
        // KeepAlive
        //  true：不会销毁
        //  false：会销毁
        public bool KeepAlive => true;

        #endregion

        #region IConfirmNavigationRequest 方法

        // 当从当前页面跳转到另一个页面触发
        // OnNavigatedFrom 调用前执行
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            // 从当前页面导航出去的时候 判断是不是需要导航出去
            // 打开某个页面
            // 
            //if (MessageBox.Show("是否打开", "导航提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    // 继续打开
            continuationCallback?.Invoke(true);
            //}
            //else
            //    // 不被打开
            //    continuationCallback?.Invoke(false);
        }

        #endregion

        #region INavigationAware 方法

        // 允许重复导航进来
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // 主 ->A -->B -->A（显示前对象)   返回true
            // 主 ->A -->B -->A（新对象）      返回false
            return true;
        }

        // 从当前View导航出去的时候触发
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // 从当前页面到另外一个页面的时候 可以把这个信息带过去
            navigationContext.Parameters.Add("B", "Hello");
        }

        // 打开当前View的时候触发
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string arg = navigationContext.Parameters.GetValue<string>("A");
        }

        #endregion
    }
}
