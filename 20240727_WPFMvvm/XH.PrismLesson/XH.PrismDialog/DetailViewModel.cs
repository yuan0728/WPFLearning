using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.PrismDialog
{
    public class DetailViewModel : IDialogAware, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }
        // 弹出窗口的标题
        public string Title => "Hello Dialog";

        // 执行关闭返回的结果
        public event Action<IDialogResult> RequestClose;

        // 当前打开的窗口是否允许关闭
        public bool CanCloseDialog()
        {
            return true;
        }

        // 弹出窗口关闭时执行逻辑
        public void OnDialogClosed()
        {

        }

        // 弹出窗口打开时执行逻辑
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Value = parameters.GetValue<string>("value");
        }

        //public string Value { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DetailViewModel()
        {
            CloseCommand = new DelegateCommand(OnClose);
        }

        private void OnClose()
        {
            IDialogResult dialogResult = new DialogResult();
            dialogResult.Parameters.Add("value", Value);
            RequestClose?.Invoke(dialogResult);
        }
    }
}
