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

namespace XH.TemplateLesson
{
    /// <summary>
    /// MenuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MenuWindow : Window
    {
        private bool _isCtrlPressed;
        private bool _isAPressed;
        public MenuWindow()
        {
            InitializeComponent();
        }
        // 下方的K 和D 根据自己写的代码来进行修改
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 先 Cttrl
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                _isCtrlPressed = true;
            }
            // 再 Ctrl + K 
            else if (e.Key == Key.K && _isCtrlPressed)
            {
                _isAPressed = true;
            }
            // 最后 Cttrl + K + D
            else if (e.Key == Key.D && _isCtrlPressed && _isAPressed)
            {
                ExecuteCustomCommand();
            }
        }
        // 键盘释放 如果释放 无效
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl)
            {
                _isCtrlPressed = false;
            }
            else if (e.Key == Key.K)
            {
                _isAPressed = false;
            }
        }

        private void ExecuteCustomCommand()
        {
            MessageBox.Show("快捷键调用成功: Ctrl + K + D");
        }

        // Ctrl + Shift + 任意子母键实现快捷键组合
        //public ICommand NewCommand { get; set; }
        //public MenuWindow()
        //{
        //    InitializeComponent();
        //    DataContext = this;
        //    NewCommand = new RelayCommand(ExecuteNew);
        //}
        //private void ExecuteNew(object parameter)
        //{
        //    MessageBox.Show("New Command Executed");
        //}


        //public class RelayCommand : ICommand
        //{
        //    private readonly Action<object> _execute;
        //    private readonly Func<object, bool> _canExecute;

        //    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        //    {
        //        _execute = execute;
        //        _canExecute = canExecute;
        //    }

        //    public bool CanExecute(object parameter)
        //    {
        //        return _canExecute == null || _canExecute(parameter);
        //    }

        //    public void Execute(object parameter)
        //    {
        //        _execute(parameter);
        //    }

        //    public event EventHandler CanExecuteChanged
        //    {
        //        add { CommandManager.RequerySuggested += value; }
        //        remove { CommandManager.RequerySuggested -= value; }
        //    }

        //}
    }
}
