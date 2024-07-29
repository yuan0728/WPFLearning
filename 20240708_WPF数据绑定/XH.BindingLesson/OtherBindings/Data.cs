using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.OtherBindings
{
    public class Data
    {
        //public int Value { get; set; } = 123;

        private int _value = 123;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }


        //public string Value2 { get; set; } = "Hello";

        private string _value2 = "Hello";

        public string Value2
        {
            get
            {
                Thread.Sleep(2000);
                return _value2;
            }
            set
            {
                _value2 = value;
            }
        }

        private double _progressValue = 0.25;

        public double ProgressValue
        {
            get { return _progressValue; }
            set { _progressValue = value; }
        }

        private int _value1 = 100;

        public int Value1
        {
            get
            {
                Thread.Sleep(3000);
                return _value1;
            }
            set
            {
                _value1 = value;
            }
        }

        private int _value3 = 300;

        public int Value3
        {
            get
            {
                Thread.Sleep(1000);
                return _value3;
            }
            set
            {
                _value3 = value;
            }
        }


    }
}
