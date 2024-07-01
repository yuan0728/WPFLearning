using System;
using System.Collections.Generic;
using System.IO;
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

namespace XH.LayoutLesson
{
    /// <summary>
    /// CanvasWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CanvasWindow : Window
    {
        public CanvasWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // 笔迹保存
            using FileStream fileStream = new FileStream("test.sk",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            this.inkCanvas.Strokes.Save(fileStream,true);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // 清除
            this.inkCanvas.Strokes.Clear();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // 加载
            using FileStream fileStream = new FileStream("test.sk", FileMode.Open, FileAccess.Read);
            this.inkCanvas.Strokes.Add(new System.Windows.Ink.StrokeCollection(fileStream));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }
    }
}
