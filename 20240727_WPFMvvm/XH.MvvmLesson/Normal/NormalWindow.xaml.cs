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

namespace XH.MvvmLesson.Normal
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class NormalWindow : Window
    {
        public NormalWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 控制逻辑
            double.TryParse(this.tb_1.Text, out double value_1);
            double.TryParse(this.tb_2.Text, out double value_2);

            //this.tb_3.Text = (this.nb_1.Value + this.nb_2.Value) + "";  
            this.tb_3.Text = (value_1 + value_2) + "";
        }
    }
}
