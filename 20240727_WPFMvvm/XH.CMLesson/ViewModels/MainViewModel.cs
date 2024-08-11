using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.CMLesson.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private int _value = 50;

        public int Value
        {
            get { return _value; }
            set
            {
                //_value = value;
                // 通知属性
                //NotifyOfPropertyChange();

                Set<int>(ref _value, value);

                // 所有属性都通知 刷新
                //this.Refresh();

                // 这里通知按钮检查使用状态 条件就是CanButtonText
                NotifyOfPropertyChange(() => CanButtonTest);
            }
        }

        // 对应名称的按钮执行逻辑
        // 命令 ：CanExcute 是否可用
        public void ButtonTest()
        {
            Value++;
        }
        // 会影响到以 ButtonText 为名称的按钮的使用状态
        public bool CanButtonTest { get => Value < 60; }

        public void EventAction(int a,int b,int c)
        {

        }
    }
}
