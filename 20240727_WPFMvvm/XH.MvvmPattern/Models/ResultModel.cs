using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.MvvmPattern.Base;

namespace XH.MvvmPattern.Models
{
    public class ResultModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Msg { get; set; }
        private int _state = 0;

        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("State"));
            }
        }

        public Command DelCommand { get; set; }

    }
}
