using Prism.Events;
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

namespace XH.PrismEventAggregator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            // 1、获取消息总线对象 通过注入的方式获取 

            // 2、通过消息对象进行订阅或者发布
            // 总线 事件对象
            #region 消息订阅

            // 订阅无参
            eventAggregator.GetEvent<EventMessage>().Subscribe(Receive);

            // 订阅带参
            // 全局静态处理 和 eventAggregator 是同一个对象
            Messenger.Defualt.GetEvent<EventMessageArgs>().Subscribe(Receive);
            // 类订阅
            Messenger.Defualt.GetEvent<EventMessageArgsList<EventMessageList>>().Subscribe(Receive);

            #endregion

            #region 消息发布

            // 发布
            //eventAggregator.GetEvent<EventMessage>().Publish();
            //// 静态发布
            //Messenger.Defualt.GetEvent<EventMessageArgs>().Publish("Hello");
            //// 类触发
            //Messenger.Defualt.GetEvent<EventMessageArgsList<EventMessageList>>().Publish(new EventMessageList()
            //{
            //    Name = "张三",
            //    Age = 18
            //});

            // 发布
            Messenger.Defualt.GetEvent<EventMessageArgs>().Publish(new EventAction()
            {
                ResultAction = new Action<bool>(state =>
                {

                })
            });

            #endregion
        }

        // 有参数触发
        private void Receive(object obj)
        {

        }
        // list 触发
        private void Receive(EventMessageList list)
        {

        }
        // 无参数触发 
        private void Receive()
        {

        }
    }
}