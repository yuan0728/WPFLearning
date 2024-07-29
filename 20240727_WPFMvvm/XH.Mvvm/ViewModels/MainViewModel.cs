using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Mvvm.Base;

namespace XH.Mvvm.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Command BtnCommand { get; set; }
        //public int Value { get; set; }

        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }


        public MainViewModel()
        {
            BtnCommand = new Command(obj =>
            {
                #region 窗口 弹窗逻辑

                // Btn的执行逻辑 打开子窗口
                // 因为不能View-->ViewModel-->View 来回调用，此方法不可取
                //new SubWindow().ShowDialog();

                //SubViewModel subViewModel = new SubViewModel();
                //subViewModel.Value = Value;

                //if (WindowProvider.ShowDialog("SubWindow", subViewModel))
                //{
                //    this.Value = subViewModel.Value;
                //}
                //else { }

                // 如何从子窗口返回到主窗口：SUbViewModel --> MainViewModel
                // 1、子窗口打开后，编辑完成，保存按钮、取消按钮
                // 2、最终数据不在子窗口处理，返回到主VM再处，保存、回退

                #endregion

                #region 方法委托逻辑
                ActionManager.Invoke<object>("sub_win",obj);
                #endregion
            });

            // 订阅的过程，
            ActionManager.Register<object>(new Action<object>(DoAction), "AAA");
            ActionManager.Register<object>(new Func<object>(DoFunc), "BBB");

        }

        private object DoFunc()
        {
            return this.Value;
        }

        private void DoAction(object obj)
        {
            
        }
    }
}
