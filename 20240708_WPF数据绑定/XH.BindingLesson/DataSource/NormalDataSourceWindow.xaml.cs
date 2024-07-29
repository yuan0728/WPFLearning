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

namespace XH.BindingLesson.DataSource
{
    /// <summary>
    /// NormalDataSourceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NormalDataSourceWindow : Window
    {
        public int Value { get; set; } = 100;
        public NormalDataSourceWindow()
        {
            InitializeComponent();

            // C# 代码完成绑定 必须依赖绑定才能设置
            // Source 数据源 Path 属性路径
            Binding binding = new Binding();
            binding.Source = Value;
            binding.Path = new PropertyPath("."); // .的含义是数据源本身
            this.tb.SetBinding(TextBlock.TextProperty, binding);
        }
    }
}
