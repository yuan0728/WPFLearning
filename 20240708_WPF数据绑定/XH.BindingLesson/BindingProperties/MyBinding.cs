using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace XH.BindingLesson.BindingProperties
{
    public class MyBinding:Binding
    {
        public MyBinding()
        {
            // 如果为空值 就显示这个数据
            this.TargetNullValue = "AAAA";
        }
    }
}
