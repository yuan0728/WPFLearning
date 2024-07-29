using System.Windows.Input;

namespace XH.MvvmPattern.Base
{
    public class Command : ICommand
    {
        // 判断绑定的当前命令实例的对象 是否可用
        // 比如按钮是否可以执行下面的逻辑
        public event EventHandler? CanExecuteChanged;

        // 外部调用
        public void RaiseCanExecuteChanged()
        {
            // 通知方法使用是否可以触发 通知状态检查
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        // 作用，触发一个时机 切换调用方的状态是否可用
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) != false;
        }
        // 参数 返回值
        private Func<object?, bool> _canExecute;


        // 绑定了当前命令实例的对象的执行逻辑
        // 等同于 Button的Click 事件
        // parameter：界面的CommandParameter属性来传值
        public void Execute(object? parameter)
        {
            // 委托 
            DoExeute?.Invoke(parameter);
        }

        public Action<object> DoExeute { get; set; }
        public Command(Action<object> action, Func<object?, bool> func = null)
        {
            DoExeute = action;
            _canExecute = func;
        }
    }
}
