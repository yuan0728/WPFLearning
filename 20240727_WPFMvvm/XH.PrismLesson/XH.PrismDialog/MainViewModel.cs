using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace XH.PrismDialog
{
    public class MainViewModel : INotifyPropertyChanged
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

        public DelegateCommand OpenCommand { get; set; }

        IDialogService _dialogService;

        public MainViewModel( IDialogService dialogService)
        {
            _dialogService = dialogService;
            OpenCommand = new DelegateCommand(OnOpen);
        }

        private void OnOpen()
        {
            // 使用事件总线的方式处理
            //_eventAggregator.GetEvent<OpenMessage>().Publish("");

            // 不使用事件总线的方式
            //使用DialogService
            // 1、传递一个名称：窗口内容对象的名称
            //                 窗口内容：UCDetail UserControl
            //                 名称：UCDetail，应该是内容注册的时候给定的名称
            // 前提是IOC容器中，创建一个UCDetail类型的对象
            // 每次打开的页面都是新实例
            // 只能打开UserControl，不能打开Window，会报根目录的问题
            //_dialogService.ShowDialog("Detail");

            // 2、获取弹窗关闭时的返回结果
            // ShowDialog(string name, Action<IDialogResult> callback)
            IDialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("value", Value);
            _dialogService.ShowDialog("Detail", dialogParameters, OnDialogClosed);

        }

        private void OnDialogClosed(IDialogResult result)
        {
            Value = result.Parameters.GetValue<string>("value");
        }
    }
}
