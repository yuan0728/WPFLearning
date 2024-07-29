using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace XH.BindingLesson.DataValidation
{
    // 实际的调用实际 是在界面上的控件被绑定的属性发生变化的时候
    // 继承 ValidationRule
    public class ValueValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // 做值的校验规则 

            // value参数指的是目标值

            if (int.TryParse(value.ToString(), out int v))
            {
                if (v == 123)
                    // 报错信息
                    return new ValidationResult(false, "值不可以为123");
            }
            else
                return new ValidationResult(false, "输入信息不是数值");
            return new ValidationResult(true, null);
        }
    }
}
