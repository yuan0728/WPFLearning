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
using XH.Mvvm.Base;

namespace XH.Mvvm.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowProvider.Register<SubWindow>(owner: this);

            ActionManager.Register<object>(new Action<object>(DoAction), "sub_win");

        }

        private void DoAction(object obj)
        {
            var win = new SubWindow();
            win.Owner = this;
            win.Show();
        }
    }
}