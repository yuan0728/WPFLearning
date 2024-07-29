using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace XH.MvvmPattern.Base
{
    // 任意事件绑定
    public class EventExtension
    {


        #region 对象和事件定死了 只能是 Button.PreviewMouseLeftButtonDown 的触发

        public static ICommand GetEventBinding(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(EventBindingProperty);
        }

        public static void SetEventBinding(DependencyObject obj, ICommand value)
        {
            obj.SetValue(EventBindingProperty, value);
        }

        // Using a DependencyProperty as the backing store for EventBinding.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventBindingProperty =
            DependencyProperty.RegisterAttached("EventBinding", typeof(ICommand), typeof(EventExtension), new PropertyMetadata(null, new PropertyChangedCallback(OnEventBindingChanged)));

        private static void OnEventBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Button).PreviewMouseLeftButtonDown += (sender, ev) =>
            {
                GetEventBinding(d as Button).Execute(null);
            };
        }

        #endregion


        // 解决：页面至少需要传递两个信息：事件名陈、命令，可以将这两个信息进行类的打包 EventCommand
        // 通过EventCommand的实例进行相关信息的获取（事件名称、命令）
        // 然后进行反射事件的委托挂载，在执行命令过程

        public static EventCommand GetEventTarget(DependencyObject obj)
        {
            return (EventCommand)obj.GetValue(EventTargetProperty);
        }

        public static void SetEventTarget(DependencyObject obj, EventCommand value)
        {
            obj.SetValue(EventTargetProperty, value);
        }

        // Using a DependencyProperty as the backing store for EventTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EventTargetProperty =
            DependencyProperty.RegisterAttached(
                "EventTarget", 
                typeof(EventCommand), 
                typeof(EventExtension), 
                new PropertyMetadata(
                    null,
                    new PropertyChangedCallback(OnEventTargetChanged)));

        private static void OnEventTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement control)
            {
                var eventCommand = e.NewValue as EventCommand;
                if (eventCommand == null) return;

                string eventName = eventCommand.EventName;
                Type controlType = control.GetType();

                bool isEvent = IsEvent(eventName, controlType);

                if (isEvent)
                {
                    EventInfo eventInfo = controlType.GetEvent(eventName);
                    if (eventInfo != null)
                    {
                        // 动态挂载事件
                        MethodInfo methodInfo = typeof(EventExtension).GetMethod("OnEventRaised", BindingFlags.NonPublic | BindingFlags.Static);
                        Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, methodInfo);
                        eventInfo.AddEventHandler(control, handler);

                        control.SetValue(EventTargetProperty, eventCommand);
                    }
                }
            }
        }
        // 挂载事件 事件转命令 
        private static void OnEventRaised(object sender, EventArgs e)
        {
            DependencyObject control = sender as DependencyObject;
            if (control == null) return;

            EventCommand eventCommand = GetEventTarget(control);
            if (eventCommand == null) return;

            ICommand command = eventCommand.Command;
            // 如果Command 获取为null，有可能是因为EventCommand对象的继承有问题，需要继承Animatable
            if (command != null && command.CanExecute(eventCommand.CommandParameter))
            {
                command.Execute(eventCommand.CommandParameter);
            }
        }
        // 判断是不是事件
        private static bool IsEvent(string eventName, Type controlType)
        {
            // 获取控件类型的所有事件
            EventInfo[] events = controlType.GetEvents();

            // 检查是否存在与给定名称匹配的事件
            foreach (EventInfo eventInfo in events)
            {
                if (eventInfo.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // 尝试：事件方法编写在vm中，然后在页面上进行指定，怎么处理

    }

    public class EventCommand : Animatable
    {
        public string EventName { get; set; }

        // 事件绑定
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(EventCommand), new PropertyMetadata(null));

        // 参数
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventCommand), new PropertyMetadata(0));


        protected override Freezable CreateInstanceCore()
        {
            return (Freezable)Activator.CreateInstance(GetType());
        }
    }
}
