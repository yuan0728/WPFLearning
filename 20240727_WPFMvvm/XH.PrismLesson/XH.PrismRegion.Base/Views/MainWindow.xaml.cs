using Prism.Regions;
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

namespace XH.PrismRegion.Base.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            // 3种添加方式
            // 1、向ViewRegion区域添加一个ViewA
            //regionManager.RegisterViewWithRegion("ViewRegion", "ViewA");
            //regionManager.RegisterViewWithRegion("ViewRegion", "ViewB");
            this.Loaded += (se, ev) =>
            {
                // 2、和RegisterViewWithRegion一样的方法
                //regionManager.AddToRegion("ViewRegion", "ViewB");

                // 激活这个注册的哪个View界面
                var region = regionManager.Regions["ViewRegion"];
                //var view = region.Views.FirstOrDefault(v => v.GetType().Name == "ViewB");
                //region.Activate(view);
                // 3、区域添加View 不用再StartUp注册也可以显示
                region.Add(new ViewB(),"ViewB");
            };
        }
    }
}