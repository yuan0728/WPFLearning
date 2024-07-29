using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.DataSource
{
    public class MethodObject
    {
        public double Calculator(string value)
        {
            return double.Parse(value) * 100;
        }
    }
}
