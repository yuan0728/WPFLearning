using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XH.Mvvm.Base
{
    public class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            DoExeute?.Invoke(parameter);
        }

        public Action<object> DoExeute { get; set; }
        public Command(Action<object> action)
        {
            DoExeute = action;
        }
    }
}
