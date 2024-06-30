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

namespace XH.StyleLesson
{
    /// <summary>
    /// ResFileWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ResFileWindow : Window
    {
        public ResFileWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.resDic.Source = new Uri("Assets/Res/Th_en.xaml",UriKind.Relative);
        }
    }
}
