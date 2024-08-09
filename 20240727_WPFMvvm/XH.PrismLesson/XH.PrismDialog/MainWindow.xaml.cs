using Prism.Events;
using Prism.Ioc;
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
using Unity;

namespace XH.PrismDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IContainerProvider containerProvider, IEventAggregator eventAggregator)
        {
            InitializeComponent();

            // 注入IOC 
            this.DataContext = containerProvider.Resolve<MainViewModel>();

            eventAggregator.GetEvent<OpenMessage>().Subscribe(OnOpen);
        }

        private void OnOpen(string arg)
        {
            // 窗口的打开
            //new SubWindow().ShowDialog();


        }
    }
}