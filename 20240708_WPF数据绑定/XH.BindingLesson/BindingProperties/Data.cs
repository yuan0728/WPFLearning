using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.BindingProperties
{
    public class Data
    {
        public string Value { get; set; } = "123";

        public int IntValue { get; set; } = 100;

        public float FloatValue { get; set; } = 0.114f;
        public DateTime DateTimeValue { get; set; } = DateTime.Now;
        public int CodeValue { get; set; } = 64; // '@'

        public bool Checked { get; set; }

        public int Gender { get; set; } = 2; // 1：男、2：女
    }
}
