using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace XH.BindingLesson
{
    public class IPCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            // 检查IP格式
            // 正则表达式
            // 核心：字符串中每个字符逐个判断

            // 192.168.1.2
            // 使用.间隔
            // 每个间隔的数字都是0-255
            // \.  \d

            string patternIpv4 = @"\b(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-4])\.){3}([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-4])\b";

            return Regex.IsMatch(value.ToString(), patternIpv4);

            //return base.IsValid(value);
        }
    }
}
