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

        public MainViewModel(IDialogService dialogService)
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
            //_dialogService.ShowDialog("Detail", OnDialogClosed);

            // 3、弹窗：请求参数
            // IDialogParameters：传给弹窗的参数信息：键值对
            IDialogParameters dialogParameters = new DialogParameters
            {
                { "value", "Hello" },
            };
            _dialogService.ShowDialog("Detail", dialogParameters, OnDialogClosed);

            // 4、可以根据注册DialogWindow窗口的名称，使用特定的窗口对象
            // 注册的窗口名称，如果指定了，必须在容器中必须存在这个名称
            // 否则报错 
            //_dialogService.ShowDialog("Detail", dialogParameters, OnDialogClosed,"win");
        }

        private void OnDialogClosed(IDialogResult result)
        {
            Value = result.Parameters.GetValue<string>("value");
        }
    }
}
