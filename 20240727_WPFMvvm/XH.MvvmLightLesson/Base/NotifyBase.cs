using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XH.MvvmLightLesson.Base
{
    // 手写MvvmLight中的值通知方法
    public class NotifyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //CallerMemberName：调用的方法或属性名称
        public void SetProperty<T>(ref T propertyName,T value, [CallerMemberName] string propName = "")
        {
            if (propertyName is null || !propertyName.Equals(value))
            {
                propertyName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
