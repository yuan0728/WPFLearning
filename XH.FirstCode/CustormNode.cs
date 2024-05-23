using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace XH.FirstCode
{
    /// <summary>
    /// 转换器
    /// </summary>
    public class CustormNode : UIElement
    {
        // 集合 List<int>
        public ValueCollection Values { get; set; } = new ValueCollection();
    }

    /// <summary>
    /// 通过类型转换器进行处理
    /// </summary>
    [TypeConverter(typeof(ValueTypeConverter))]
    public class ValueCollection
    {
        private readonly List<int> _values = new List<int>();

        public void Append(int[] val)
        {
            _values.AddRange(val);
        }
    }

    class ValueTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            ValueCollection vc = new ValueCollection();
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return base.ConvertFrom(context, culture, value!);
            string[] temp = value.ToString()!.Split(',');
            vc.Append(temp.Select(vs =>
            {
                int v = 0;
                int.TryParse(vs, out v);
                return v;
            }).ToArray());
            return vc;
        }
    }
}
