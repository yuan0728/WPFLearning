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

namespace XH.BindingLesson.DataCollection
{
    /// <summary>
    /// DataCollectionWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataCollectionWindow : Window
    {
        DataSource ds = new DataSource();
        public DataCollectionWindow()
        {
            InitializeComponent();

            //this.lb.ItemsSource = new List<string>() { "AAA","BBB","CCC"};

            this.DataContext = ds;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ds.List.Add(new DataItem { Id = 1, Header = "DDD" });
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
