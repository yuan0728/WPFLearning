using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BindingLesson.DataValidation
{
    public class CheckRepeatAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            // 数据有误的检查逻辑
            return false;
        }
    }
}
