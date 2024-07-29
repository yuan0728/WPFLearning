using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace XH.EventLesson
{
    /// <summary>
    /// CustomEventWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CustomEventWindow : Window
    {
        public CustomEventWindow()
        {
            InitializeComponent();

            Test test = new Test();
            test.CustomEvent += Test_CustomEvent;
            test.CustomEvent -= Test_CustomEvent;
            test.CustomStringEvent += Test_CustomStringEvent;
            test.CustomStringEvent -= Test_CustomStringEvent;


            //ParentClass parentClass = new ParentClass();
            //parentClass.Tap += ParentClass_Tap;
            //parentClass.Tap -= ParentClass_Tap;

        }


        private void Test_CustomStringEvent(object? sender, string e)
        {
            throw new NotImplementedException();
        }
        private void Test_CustomEvent(object? sender, MyEventArags e)
        {
            string value = e.Value;
            throw new NotImplementedException();
        }

        private void ChildClass_Tap(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("================ChildClass_Tap================");
        }
        private void ParentClass_Tap(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("================ParentClass_Tap================");
        }

        private void ParentClass_PreviewTap(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("================ParentClass_PreviewTap================");
        }

        private void ChildClass_PreviewTap(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("================ChildClass_PreviewTap================");
        }

        private void Grid_PreviewTap(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("================Grid_PreviewTap================");
        }

        private void Grid_Tap(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("================Grid_Tap================");
        }
    }
    // 普通事件
    class Test
    {
        // Framework 4.0 及以下框架下 可以使用
        public event EventHandler<MyEventArags> CustomEvent;

        // 4.5 及以上可以已使用以下方式
        public event EventHandler<string> CustomStringEvent;

        public Test()
        {
            CustomEvent?.Invoke(this, new MyEventArags() { Value = "Hello" });
            CustomStringEvent?.Invoke(this, "Hello");
        }
    }

    class MyEventArags : EventArgs
    {
        public string Value { get; set; }
    }

    // 用于路由事件

    public class BaseClass : ContentControl
    {
        // 路由事件的声明与注册（冒泡事件）
        protected static readonly RoutedEvent TapEvent =
            EventManager.RegisterRoutedEvent(
                "Tap",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(BaseClass));

        // 封装
        public event RoutedEventHandler Tap
        {
            add => AddHandler(TapEvent, value);
            remove => RemoveHandler(TapEvent, value);
        }

        // 封装
        public event RoutedEventHandler PreviewTap
        {
            add => AddHandler(PreviewTapEvent, value);
            remove => RemoveHandler(PreviewTapEvent, value);
        }
        // 路由事件的声明与注册（隧道事件）
        protected static readonly RoutedEvent PreviewTapEvent =
            EventManager.RegisterRoutedEvent(
                "PreviewTap",
                RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler),
                typeof(BaseClass));

        // 封装
        public event RoutedEventHandler MyEvent
        {
            add => AddHandler(MyEventEvent, value);
            remove => RemoveHandler(MyEventEvent, value);
        }
        // 路由事件的声明与注册
        protected static readonly RoutedEvent MyEventEvent =
            EventManager.RegisterRoutedEvent(
                "MyEvent",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(BaseClass));


    }

    public class ParentClass : BaseClass
    {
        // 代码片段 自定义 
    }

    public class ChildClass : BaseClass
    {
        public ChildClass()
        {
            // 场景 类里数据执行到某个时机的时候 触发上面的路由事件
            Task.Run(async () =>
            {
                await Task.Delay(2000);

                // 触发路由事件
                this.Dispatcher.Invoke(() =>
                {
                    // 冒泡：从里到外，隧道：从外到里
                    // 先Child 在 Parent
                    this.RaiseEvent(new RoutedEventArgs(TapEvent, this));
                    // 先Parent 在 Child
                    this.RaiseEvent(new RoutedEventArgs(PreviewTapEvent, this));
                });
            });
        }

    }
}
