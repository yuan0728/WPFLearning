using Caliburn.Micro;
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

namespace XH.CMLesson.EA
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window, IHandle<string>, IHandle<Message>
    {
        public MainView()
        {
            InitializeComponent();

            // 可以构造函数注入 也可以静态调用
            // 这种方式获取注入对象实例 不仅在View中使用，在VM中也可以使用
            IoC.Get<IEventAggregator>().SubscribeOnUIThread(this);
        }

        public Task HandleAsync(string message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task HandleAsync(Message message, CancellationToken cancellationToken)
        {
            // 有数据返回到发布方
            // 被动触发，触发之后，经过逻辑处理，希望有个数据返回到调用方
            int value = 789;
            message.Callback?.Invoke(value);

            return Task.CompletedTask;
        }
    }
}
