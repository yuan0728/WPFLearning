using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace XH.CMLesson.WM.ViewModels
{
    // Screen：
    // Conductor 是 Screen 进一步的封装
    public class BViewModel : Conductor<object> // Screen
    {
        public BViewModel()
        {
            //this.ActiveItem;
        }

        // 当对应的view页面对象加载完成后触发
        // 构造：
        // 渲染完成：
        // 构造 --> 渲染完成
        // 页面初始化
        protected override void OnViewLoaded(object view)
        {
            // 判断当前对象是不是Popup对象，是的话 就让他的 StaysOpen 属性设置false
            if (this.GetView() is Popup popup)
            {
                popup.StaysOpen = false;
            }
        }


        public void OnClose()
        {
            // 关闭当前View
            this.TryCloseAsync();
        }
    }
}
