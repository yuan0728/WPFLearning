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

namespace XH.BindingLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         关于数据绑定：
            Binding C# XAML {Binding} MarkupExtension
            绑定：描述的是一种关系，同过某种关系将多个实物联系在一起
            通常情况下，每个绑定具有四个组件
                绑定目标对象
                目标属性
                绑定源
                制定绑定源中要使用的值的路径
            数据绑定的典型用法是将服务器或本地配置数据放置到窗体或其他UI控件中，不要绑定什么元素，也不论数据源是什么性质，每个绑定都始终遵循 DependencyObject <--> Property
         
        数据绑定中的数据源
            指定方式：
                DataContext Source ElementName RelativeSource
                Path XPath
            数据源类型：
                依赖对象做为数据源
                普通数据类型或集合做为数据源
                单个对象做为数据源
                ADO.NET数据对象做为数据源
                ObjectDataProvider做为数据源
                Linq结果做为数据源：List
                XmlDataProvider做为数据源
                静态对象属性
         */
        public MainWindow()
        {
            InitializeComponent();

            Binding binding = new Binding();
        }
    }
}