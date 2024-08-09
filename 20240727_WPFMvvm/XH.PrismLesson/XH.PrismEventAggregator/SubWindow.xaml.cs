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

namespace XH.PrismEventAggregator
{
    /// <summary>
    /// SubWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();

            // 1、无参数的订阅
            // Messenger.Defualt.GetEvent<EventMessageArgs>().Subscribe(Receive);

            // 2、过滤的订阅
            // 第一个参数：执行方法
            // 第二个参数：过滤器，可以根据什么条件进行过滤，满足条件之后才会执行第一个参数方法
            // Subscribe(Action<TPayload> action, Predicate<TPayload> filter)
            // Messenger.Defualt.GetEvent<EventMessageArgs>().Subscribe(Receive1, obj => obj.Id == 1);

            //3、 消息委托的引用方式
            // 第二个参数默认设置为false，指定委托的强引用和弱引用：
            // true：强引用，不关闭一直打开，在对象销毁的时候做注销操作；
            // false：弱引用，自动释放
            // Subscribe(Action<TPayload> action, bool keepSubscriberReferenceAlive)
            // Messenger.Defualt.GetEvent<EventMessageArgs>().Subscribe(Receive1,true);

            ///4、ThreadOption：多线程状态控制
            // Subscribe(Action<TPayload> action, ThreadOption threadOption)
            // PublisherThread：发布者在什么线程发布的，注册的逻辑就在哪个线程执行 默认此方法
            // UIThread：不管发布者在什么线程发布的，注册的逻辑总是在非UI线程（主线程）执行
            //           如果在执行逻辑里有页面的操作，可以使用这个
            // BackgroundThread：不管发布者在哪个线程发布，注册的逻辑总是在后台线程执行 
            //                   例如写日志，不在UI线程和当前线程执行，就在后台线程执行
            //                   新建一个线程，把当前逻辑包起来 跟发布方无关
            Messenger.Defualt.GetEvent<EventMessageArgs>().Subscribe(Receive1, Prism.Events.ThreadOption.BackgroundThread);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // 反注册 销毁
            Messenger.Defualt.GetEvent<EventMessageArgs>().Unsubscribe(Receive1);
        }

        private void Receive1(DataModel obj)
        {
            var id = Thread.CurrentThread.ManagedThreadId;
        }

        private void Receive(object obj)
        {
            var ea = (EventAction)obj;
            ea.ResultAction?.Invoke(true);
        }
    }
}
