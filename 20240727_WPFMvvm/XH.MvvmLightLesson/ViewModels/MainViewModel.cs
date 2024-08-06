using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XH.MvvmLightLesson.Base;
using XH.MvvmLightLesson.BLL;
using XH.MvvmLightLesson.DataAccess;
using XH.MvvmLightLesson.Models;

namespace XH.MvvmLightLesson.ViewModels
{
    public class MainViewModel : ViewModelBase //ObservableObject
    {
        public MainModel MainModel { get; set; } = new MainModel();
        //public int Value { get; set; }
        // Value变化时 界面同步变化 

        private string _value = "Hello";

        public string Value
        {
            get { return _value; }
            set
            {
                // 第一种通知方式
                //this.RaisePropertyChanged();
                //_value = value;

                // 第二种通知方式
                Set<string>(ref _value, value);
                // 调用按钮是否可以使用的事件
                BtnCommand?.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<string> ValueList { get; set; } = new ObservableCollection<string>();

        // MvvmLight中的绑定方法：RelayCommand
        public RelayCommand BtnCommand { get; set; }
        public RelayCommand<object> BtnParamCommand { get; set; }

        [Dependy("LoginBLL")]
        public ILoginBLL loginBLL { get; set; }
        public MainViewModel([Dependy("SqlServerDA")]IDataAccess dataAccess) // SqlServerDA
        {
            // 获取配置数据  数据库  数据接口  耗时操作
            if (this.IsInDesignMode) return;
            //if (this.IsInDesignMode)
            //{
            //    // 设计时 模拟数据处理 

            //    Value = "Hello XiaoHai";
            //}
            //else
            //{
            //    // 运行时执行

            //    Value = "你好 小海";
            //}
            BtnCommand = new RelayCommand(DoButtonCommand, DoButtonStatus);
            BtnParamCommand = new RelayCommand<object>(DoBtnParamCommand);

            Task.Run(async () =>
            {
                await Task.Delay(1000); 
                for (int i = 0; i < 10; i++)
                {
                    // 这句话需要在UI线程执行
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ValueList.Add($"Xiao Hai -- {i}");
                    });
                    //int localI = i; // 创建一个新的局部变量来存储当前迭代的i值  
                    // CheckBeginInvokeOnUI：异步执行
                    //DispatcherHelper.CheckBeginInvokeOnUI(() =>
                    //{
                    //    ValueList.Add($"Xiao Hai -- {localI}");
                    //});
                }
            });
        }

        private void DoButtonCommand()
        {
            loginBLL.Login();
        }

        private bool DoButtonStatus()
        {
            return Value == "Hello";
        }

        private void DoBtnParamCommand(object obj)
        {
            // 主动 发布
            // 根据类型绑定、Key
            //Messenger.Default.Send<string>(Value);
            //Messenger.Default.Send<string>(Value, "SubWin");
            Messenger.Default.Send<Base.MessageBase>(new Base.MessageBase { Value = Value, Action = GetResult });
        }

        private void GetResult(bool obj)
        {

        }


        // 作用：统一执行对象的资源清理 VM的释放
        // View关闭退出的时候 后台线程需要结束
        public override void Cleanup()
        {
            base.Cleanup();
        }

    }
}
