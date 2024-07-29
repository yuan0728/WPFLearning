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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XH.EventLesson
{
    /// <summary>
    /// UserControl.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            // 指定路由处理器 
            // 强调鼠标左键的冒泡事件
            this.AddHandler(
                MouseLeftButtonDownEvent,
                new MouseButtonEventHandler(UserControl_MouseLeftButtonDown),
                true);
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("==================UserControl_MouseLeftButtonDown======================");
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("==================Border_MouseLeftButtonDown======================");

            // 禁止路由事件传递
            e.Handled = true;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("==================Grid_MouseLeftButtonDown======================");
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("==================Grid_Click======================");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("==================Button_Click======================");
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("==================Grid_PreviewMouseLeftButtonDown======================");
        }

        private void TextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            Debug.WriteLine("==================TextBox_TextInput======================");
        }
    }
}
