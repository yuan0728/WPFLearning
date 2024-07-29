using System;
using System.Collections.Generic;
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

namespace XH.EventLesson
{
    /// <summary>
    /// TouchEventWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TouchEventWindow : Window
    {
        public TouchEventWindow()
        {
            InitializeComponent();
        }

        private void Border_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // 1、获取触点，有几个 判断多个点的关系
        }
    }
}
