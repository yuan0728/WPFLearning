using GalaSoft.MvvmLight.Messaging;
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
using XH.MvvmLightLesson.ViewModels;

namespace XH.MvvmLightLesson.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 只有在运行时才执行
            //this.DataContext = new MainViewModel();

            // MvvmLight基本的注册过程
            Messenger.Default.Register<string>(this, ExecuteMessage);

            //Messenger.Default.Register<string>(this, ExecuteMessage2);

            // 如果需要区分这两个执行逻辑 两个方法：
            // 1、使用Token（Key）
            Messenger.Default.Register<string>(this,"SubWin", ExecuteMessageSubWin);
            // 2、使用类型区分 复杂的数据传参
            Messenger.Default.Register<Base.MessageBase>(this, ExecuteMessageType);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // 反注册 注销
            Messenger.Default.Unregister<string>(this);
        }

        private void ExecuteMessageType(Base.MessageBase obj)
        {
            //throw new NotImplementedException();
            var result = new SubWindow { Owner = this }.ShowDialog() == true;

            obj.Action?.Invoke(result);
        }

        private void ExecuteMessageSubWin(string obj)
        {
            new SubWindow { Owner = this }.ShowDialog();
        }

        private void ExecuteMessage2(string obj)
        {
            //throw new NotImplementedException();
        }

        private void ExecuteMessage(string obj)
        {
            new SubWindow { Owner = this }.ShowDialog();
        }
    }
}