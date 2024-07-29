using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace XH.EventLesson
{
    /// <summary>
    /// DragDropEventWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DragDropEventWindow : Window
    {
        public DragDropEventWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_DragEnter(object sender, DragEventArgs e)
        {
            (sender as StackPanel).Background = Brushes.LightGray;
            Debug.WriteLine("==============StackPanel_DragEnter==============");
        }

        private void StackPanel_DragLeave(object sender, DragEventArgs e)
        {
            (sender as StackPanel).Background = Brushes.Transparent;
            Debug.WriteLine("==============StackPanel_DragLeave==============");
        }

        private void StackPanel_DragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine("==============StackPanel_DragOver==============");
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("==============StackPanel_Drop==============");

            //FrameworkElement ctl = (FrameworkElement)e.Data.GetData(typeof(Border));
            //(ctl.Parent as StackPanel).Children.Remove(ctl);
            //(sender as StackPanel).Children.Add(ctl);

            string brush = (string)e.Data.GetData(typeof(string));
            Border border = new Border()
            {
                Height = 30,
                Margin = new Thickness(10),
                Background = (Brush)new BrushConverter().ConvertFromString(brush),
            };
            border.MouseLeftButtonDown += Border_MouseLeftButtonDown;
            (sender as StackPanel).Children.Add(border);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            // 开始一个拖动处理 准备相关数据
            // DragDropEffects 只关注鼠标状态和显示 不负责拖拽对象
            DragDrop.DoDragDrop(border, border.Background.ToString(), DragDropEffects.Move);
        }
    }
}
