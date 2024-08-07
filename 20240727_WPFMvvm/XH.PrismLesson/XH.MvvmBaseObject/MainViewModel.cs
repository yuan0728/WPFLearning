using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.MvvmBaseObject
{
    public class MainViewModel : BindableBase
    {
        // 基本的通知属性
        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                // 通知属性 第一种方式
                SetProperty<string>(ref _value, value);
                // 第二种方式
                //_value = value;
                //this.RaisePropertyChanged("Value");
                // 第三种方式
                //_value = value;
                //this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Value"));
            }
        }

        // 命令属性定义
        public DelegateCommand<object> BtnCommand { get; set; }

        public MainViewModel()
        {
            // 初始化
            BtnCommand = new DelegateCommand<object>((arg) =>
            {

            });
        }

    }
}

