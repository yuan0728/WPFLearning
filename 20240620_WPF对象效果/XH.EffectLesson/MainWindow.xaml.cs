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

namespace XH.EffectLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // C#代码设置Path
            string strPath = "M0 0 10 100";

            this.path.Data = PathGeometry.Parse(strPath);

            // 1、可以根据Brushes直接设置
            this.br.Background = Brushes.AliceBlue;
            // 2、根据RGB进行设置 
            this.br.Background = new SolidColorBrush(Color.FromRgb(255,0,0));
            // 3、根据ARGB进行设置 比RGB多一个第一个16进制数字，表示颜色的深浅度，数字越大越深，反之越浅
            this.br.Background = new SolidColorBrush(Color.FromArgb(255,0,0,0));
            // 4、根据#二十六进制进行表示
            this.br.Background = new BrushConverter().ConvertFrom("#FFCAC2AD") as SolidColorBrush;
        }
    }
}