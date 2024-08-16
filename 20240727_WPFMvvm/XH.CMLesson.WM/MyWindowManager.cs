using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;

namespace XH.CMLesson.WM
{
    public class MyWindowManager:WindowManager 
    {
        // 动态创建对应窗口的时候 调用
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            Window window = base.EnsureWindow(model, view, isDialog);

            // 同过代码设置无边框
            WindowChrome windowChrome = new WindowChrome();
            windowChrome.GlassFrameThickness = new Thickness(0);
            WindowChrome.SetWindowChrome(window, windowChrome);

            window.Width = 300;
            window.Height = 300;

            return window;
        }
    }
}
