using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.MvvmPattern.Models
{
    public class MainModel : INotifyPropertyChanged
    {


        private double _value1 = 100;

        public double Value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value1"));
            }
        }

        private double _value2 = 200;

        public double Value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value2"));
            }
        }

        private double _value3;

        public double Value3
        {
            get { return _value3; }
            set
            {
                _value3 = value;
                // 在系统内广而告之 告诉页面上哪个对象关注了这个实例里的这个属性的，赶紧更新结果
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value3"));
            }
        }

        // 做信息发布的对象 需要执行这一下这个对象
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
