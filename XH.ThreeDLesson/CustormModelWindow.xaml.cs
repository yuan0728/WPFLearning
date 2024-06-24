using HelixToolkit.Wpf;
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

namespace XH.ThreeDLesson
{
    /// <summary>
    /// CustormModelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustormModelWindow : Window
    {
        public CustormModelWindow()
        {
            InitializeComponent();
            this.Loaded += CustormModelWindow_Loaded;
        }

        private void CustormModelWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ModelImporter importer = new ModelImporter();


            model.Content = importer.Load("D:\\Users\\yhl18\\Desktop\\无标题.obj");
        }
    }
}
