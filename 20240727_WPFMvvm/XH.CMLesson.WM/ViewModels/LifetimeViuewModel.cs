using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.WM.ViewModels
{
    // 生命周期
    public class LifetimeViuewModel : Screen
    {
        public LifetimeViuewModel()
        {
            // 关闭对应的View
            //this.TryCloseAsync();
        }
        // 页面加载
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        // 准备加载 在 OnViewLoaded 之前触发
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
        }

        // 页面处于激活窗口的时候
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return base.OnActivateAsync(cancellationToken);
        }

        // 离开正在激活窗口 
        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            return base.OnDeactivateAsync(close, cancellationToken);
        }

        // 是否能够关闭窗口
        public override Task<bool> CanCloseAsync(CancellationToken cancellationToken = default)
        {
            return base.CanCloseAsync(cancellationToken);
        }
    }
}
