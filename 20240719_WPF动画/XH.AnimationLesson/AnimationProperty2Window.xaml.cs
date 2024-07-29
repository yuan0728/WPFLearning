using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XH.AnimationLesson
{
    /// <summary>
    /// AnimationProperty2Window.xaml 的交互逻辑
    /// </summary>
    public partial class AnimationProperty2Window : Window
    {
        public AnimationProperty2Window()
        {
            InitializeComponent();
        }
        // 顺序：CurrentTimeInvalidated-->CurrentGlobalSpeedInvalidated
        // -->CurrentStateInvalidated-->...CurrentTimeInvalidated...-->CurrentGlobalSpeedInvalidated
        // -->CurrentStateInvalidated-->Completed
        // 结束故事线
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            Debug.WriteLine("==============Storyboard_Completed===========");
        }
        // 速度变化 
        private void Storyboard_CurrentGlobalSpeedInvalidated(object sender, EventArgs e)
        {
            Debug.WriteLine("==============Storyboard_CurrentGlobalSpeedInvalidated===========");
        }
        // 状态变化 静止-->运行 
        private void Storyboard_CurrentStateInvalidated(object sender, EventArgs e)
        {
            Debug.WriteLine("==============Storyboard_CurrentStateInvalidated===========");
        }
        // 时间线开始
        // 时间轴触发 是根据帧率来的 
        private void Storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            // 可以根据此事件来处理监控的变化
            Debug.WriteLine("==============Storyboard_CurrentTimeInvalidated===========");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var v1 = border1.Margin;
            var v2 = border2.Margin;
            var v3 = border3.Margin;

            this.border1.Margin = new Thickness(200, 0, 0, 0);
            // 对象先进行动画变化 完成之后进行相关的属性设置 发现设置不了。。

        }
    }
}
