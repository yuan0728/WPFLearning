using Prism.Ioc;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XH.PrismDialog
{
    /// <summary>
    /// UCDetail.xaml 的交互逻辑
    /// </summary>
    public partial class UCDetail : UserControl
    {
        public UCDetail(IContainerProvider containerProvider)
        {
            InitializeComponent();

            // 1.明确需要获取某个对象 并且这个对象里需要自动注入一些内容
            // 2.在IOC创建的过程，需要注入的对象，都需要注册
            this.DataContext = containerProvider.Resolve<DetailViewModel>();
        }
    }
}
