using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 需求：页面销毁
            // VM 交互逻辑对象  线程（循环线程）
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 当前页面退出 关闭
            //this.Close();

            int i = 0;
            var res = 100 / i;

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // APP 退出
            //Application.Current.Shutdown();
            GC.Collect();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            // 系统环境退出 杀进程 不执行App_Exit事件
            System.Environment.Exit(0);
        }

        // =============================鼠标事件=====================================
        // 鼠标左击事件
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}