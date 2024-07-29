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
    /// DataContextWindwo.xaml 的交互逻辑
    /// </summary>
    public partial class DataContextWindow : Window
    {
        public DataContextWindow()
        {
            InitializeComponent(); 

            // 依赖对象
            //this.DataContext = this;
            // 普通数据类型
            //this.DataContext = "ABCD";
            // 单个对象示例
            this.DataContext = new Person()
            {
                Name="张三",
                Age = 18
            };
        }
    }
}
