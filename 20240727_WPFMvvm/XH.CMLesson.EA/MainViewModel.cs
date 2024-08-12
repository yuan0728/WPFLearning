using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.EA
{
    // 如果需要接受多个参数的订阅 就写多个接口即可
    // Object：类型：什么类型的都可以接受
    public class MainViewModel : IHandle<Message>, IHandle<string>
    {
        IEventAggregator _eventAggregator;
        public MainViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            // 弃用
            eventAggregator.Subscribe(this);

            // 订阅按照哪种线程进行执行订阅逻辑
            // 永远在后台线程执行
            //eventAggregator.SubscribeOnBackgroundThread(this);
            // 在发布者的线程中执行
            //eventAggregator.SubscribeOnPublishedThread(this);
            // 永远在UI线程中执行
            //eventAggregator.SubscribeOnUIThread(this);

            // 订阅-->发布
            // 执行逻辑：使用接口方法进行处理 IHandler<T>
        }

        // 根据类型来进行匹配 发送信息的时候调用
        public Task HandleAsync(Message message, CancellationToken cancellationToken)
        {
            // 最终的执行线程并不是由发布者决定的 是由订阅者决定
            var id = Thread.CurrentThread.ManagedThreadId;

            return Task.CompletedTask;
        }

        // 只要是同一个类型 都可以接收到
        // 如果不同的订阅，需要通过类型来区分
        public Task HandleAsync(string message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async void Send()
        {
            // 点击按钮的时候 执行发布动作
            // 消息内容是根据消息类型进行匹配的
            await _eventAggregator.PublishOnCurrentThreadAsync(new Message { Callback = OnCallback });
            //await _eventAggregator.PublishOnCurrentThreadAsync("Hello");
            //_eventAggregator.PublishOnBackgroundThreadAsync(this);
            //_eventAggregator.SubscribeOnUIThread(this);
        }

        private void OnCallback(int obj)
        {
            
        }
    }
}
